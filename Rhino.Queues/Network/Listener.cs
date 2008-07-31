using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using log4net;
using Rhino.Queues.Impl;

namespace Rhino.Queues.Network
{
	using System.Transactions;

	public class Listener : IListener
	{
		private readonly ILog logger = LogManager.GetLogger(typeof(Listener));
		private readonly HttpListener listener;
		private readonly IQueueFactoryImpl queueFactory;
		private readonly int workerThreadsCount;
		private bool active = true;
		private readonly IList<Thread> threads = new List<Thread>();
		SizedLimitedSet<Guid> recievedMessagesIds = new SizedLimitedSet<Guid>(1000000);

		public Listener(IQueueFactoryImpl queueFactory, int workerThreadsCount, string endpoint)
		{
			listener = new HttpListener();
			listener.Prefixes.Add(endpoint);
			this.queueFactory = queueFactory;
			this.workerThreadsCount = workerThreadsCount;
		}

		public void Start()
		{
			logger.DebugFormat("Starting listner with {0} threads", workerThreadsCount);
			listener.Start();
			for (var i = 0; i < workerThreadsCount; i++)
			{
				var thread = new Thread(Recieve)
				{
					IsBackground = true
				};
				threads.Add(thread);
				thread.Start();
			}
		}

		private void Recieve()
		{
			while (active)
			{
				try
				{
					var context = listener.GetContext();
					logger.Debug("new request accepted");
					RecieveRequest(context);
				}
				catch (HttpListenerException)
				{
					return;
				}
				catch (ObjectDisposedException)
				{
					return;
				}
			}
		}

		private void RecieveRequest(HttpListenerContext context)
		{
			using (context.Response)
			{
				if (ValidateRequest(context) == false)
					return;
				var msgs = DeserializeRequest(context);
				if (msgs == null)
					return;
				if (ValidateAllMessageHasValidQueues(context, msgs) == false)
					return;
				try
				{
					using(var tx = new TransactionScope())
					{
						var messagesByQueue = from m in msgs
											  group m by m.Destination.Queue
												  into g
												  select new { Queue = g.Key, Messages = g.ToArray() };

						foreach (var q in messagesByQueue)
						{
							var messages = FilterDuplicateMessages(q.Messages).ToArray();
							if (messages.Length == 0)
								continue;
							queueFactory.OpenQueueImpl(q.Queue).PutAll(messages);
							RecordMessageIds(messages);
						}
						context.Response.StatusCode = (int)HttpStatusCode.OK;
						tx.Complete();
					}
				}
				catch (Exception e)
				{
					logger.Warn("Error when processing request", e);
					context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
					using (var sw = new StreamWriter(context.Response.OutputStream))
					{
						sw.WriteLine("Failed to accept messages because: " + e.Message);
					}
				}
			}
		}

		private void RecordMessageIds(IEnumerable<TransportMessage> messages)
		{
			lock (recievedMessagesIds)
			{
				foreach (var message in messages)
				{
					recievedMessagesIds.Add(message.Id);
				}
			}
		}

		private IEnumerable<TransportMessage> FilterDuplicateMessages(IEnumerable<TransportMessage> messages)
		{
			lock (recievedMessagesIds)
			{
				foreach (var message in messages)
				{
					if (recievedMessagesIds.Exists(message.Id) == false)
						yield return message;
				}
			}
		}

		private bool ValidateAllMessageHasValidQueues(HttpListenerContext context, IEnumerable<TransportMessage> msgs)
		{
			bool allValid = true;
			foreach (var message in msgs)
			{
				if (message.Destination == null || string.IsNullOrEmpty(message.Destination.Queue))
				{
					allValid = false;
					context.Response.StatusCode = (int)HttpStatusCode.NotFound;
					using (var writer = new StreamWriter(context.Response.OutputStream))
					{
						logger.WarnFormat("Message {0} doesn't have a queue specified", message.Id);
						writer.WriteLine("{0}:InvalidQueue", message.Id);
					}
				}
				else if (queueFactory.HasQueue(message.Destination.Queue) == false)
				{
					allValid = false;
					context.Response.StatusCode = (int)HttpStatusCode.NotFound;
					using (var writer = new StreamWriter(context.Response.OutputStream))
					{
						logger.WarnFormat("Message {0} specified queue {1} which doesn't exists", message.Id, message.Destination.Queue);
						writer.WriteLine("{0}:QueueNotFound", message.Id);
					}
				}

			}
			return allValid;
		}

		private TransportMessage[] DeserializeRequest(HttpListenerContext context)
		{
			try
			{
				return Deserialize(context.Request);
			}
			catch (Exception e)
			{
				context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
				using (var sw = new StreamWriter(context.Response.OutputStream))
				{
					logger.Warn("request invalid data rejected");
					sw.WriteLine("Failed to deserialize messages because: " + e.Message);
				}
				return null;
			}
		}

		private bool ValidateRequest(HttpListenerContext context)
		{
			if (context.Request.HttpMethod != "PUT")
			{
				context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
				using (var sw = new StreamWriter(context.Response.OutputStream))
				{
					logger.Warn("non PUT request rejected");
					sw.WriteLine("Only PUT requests are allowed");
				}
				return false;
			}
			return true;
		}

		public void Dispose()
		{
			active = false;
			listener.Stop();
			listener.Close();
			foreach (var thread in threads)
			{
				if (thread != Thread.CurrentThread)
					thread.Join();
			}
		}

		public TransportMessage[] Deserialize(HttpListenerRequest request)
		{
			return (TransportMessage[])new BinaryFormatter().Deserialize(request.InputStream);
		}
	}
}