using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using MbUnit.Framework;
using Rhino.Queues.Impl;
using Rhino.Queues.Network;
using Rhino.Queues.Storage;
using Rhino.Queues.Storage.InMemory;
using Rhino.Queues.Tests.Units;

namespace Rhino.Queues.Tests.Network
{
	[TestFixture]
	public class SenderTests
	{
		private IMessageStorage localStorage;
		private TestMessageStorageFactory remoteMessageStorageFactory;
		private Sender sender;
		private QueueFactoryImpl queueFactoryImpl;

		[SetUp]
		public void SetUp()
		{
			localStorage = new InMemoryMessageStorage(new HashSet<string>
			{
				"http://localhost/test/"
			});
			remoteMessageStorageFactory = new TestMessageStorageFactory();
			queueFactoryImpl = new QueueFactoryImpl("test",
													remoteMessageStorageFactory, new Dictionary<string, string>
			                                        {
			                                        	{"test", "http://localhost/test/"}
			                                        }, new[] { "test" }, new ListenerFactory(1), new SenderFactory(1));

			queueFactoryImpl.Start();
		}

		[TearDown]
		public void TearDown()
		{
			queueFactoryImpl.Dispose();
		}

		[Test]
		public void Can_start_and_stop()
		{
			using (sender = new Sender(localStorage, 1))
			{
				sender.Start();
				localStorage.Dispose();
			}
		}

		[Test]
		public void Will_send_new_message_when_they_arrive()
		{
			using (sender = new Sender(localStorage, 1))
			{
				sender.Start();
				localStorage.Add("http://localhost/test/", new TransportMessage
				{
					Message = new Message { Value = 1 },
					Destination = new Destination { Queue = "test" }
				});
				remoteMessageStorageFactory.IncomingStorage.WaitForNewMessages();
				var msg = remoteMessageStorageFactory.IncomingStorage.PullMessagesFor("test").First();
				Assert.AreEqual(1, msg.Message.Value);
				localStorage.Dispose();
			}
		}


		[Test]
		public void Will_not_send_messages_whose_send_at_data_is_in_the_future()
		{
			using (sender = new Sender(localStorage, 1))
			{
				var resetEvent = new ManualResetEvent(false);
				sender.NothingToSend += () => resetEvent.Set();
				sender.Start();
				localStorage.Add("http://localhost/test/", new TransportMessage
				{
					Message = new Message { Value = 1 },
					Destination = new Destination { Queue = "test" },
					SendAt = SystemTime.Now().AddHours(1)
				});
				resetEvent.WaitOne();
				var msg = remoteMessageStorageFactory.IncomingStorage.PullMessagesFor("test").FirstOrDefault();
				Assert.IsNull(msg);

				localStorage.Dispose();
			}
		}

		[Test]
		public void Will_send_batches_of_max_100_messages()
		{
			using (sender = new Sender(localStorage, 1))
			{
				for (int i = 0; i < 400; i++)
				{
					localStorage.Add("http://localhost/test/", new TransportMessage
					{
						Message = new Message { Value = 1 },
						Destination = new Destination { Queue = "test" }
					});
				}
				var resetEvent = new ManualResetEvent(false);
				sender.BatchSent += () =>
				{
					sender.Dispose();
					resetEvent.Set();
				};
				sender.Start();
				resetEvent.WaitOne();
				localStorage.Dispose();
			}
			var count = remoteMessageStorageFactory.IncomingStorage.PullMessagesFor("test").Count();
			Assert.AreEqual(100, count);
		}

		[Test]
		public void Will_send_all_messages_in_queue()
		{
			using (sender = new Sender(localStorage, 1))
			{
				for (int i = 0; i < 400; i++)
				{
					localStorage.Add("http://localhost/test/", new TransportMessage
					{
						Message = new Message { Value = i },
						Destination = new Destination { Queue = "test" }
					});
				}
				var resetEvent = new ManualResetEvent(false);
				int j = 0;
				sender.BatchSent += () =>
				{
					j += 1;
					if (j == 4)
					{
						sender.Dispose();
						resetEvent.Set();
					}
				};
				sender.Start();
				resetEvent.WaitOne();
				localStorage.Dispose();
			}
			var count = remoteMessageStorageFactory.IncomingStorage.PullMessagesFor("test").Count();
			Assert.AreEqual(400, count);
		}

		[Test]
		public void When_send_fail_will_put_items_back_in_queue()
		{
			using (sender = new Sender(localStorage, 1))
			{
				sender.Start();
				var resetEvent = new ManualResetEvent(false);
				sender.Error += (e, t) =>
				{
					sender.Dispose();
					resetEvent.Set();
				};
				localStorage.Add("http://localhost/test/", new TransportMessage
				{
					Message = new Message { Value = 1 },
					Destination = new Destination { Queue = "test2" }
				});
				resetEvent.WaitOne();
				localStorage.Dispose();
			}
			localStorage.WaitForNewMessages();
			var msg = localStorage.PullMessagesFor("http://localhost/test/").First();
			Assert.AreEqual(1, msg.Message.Value);
		}

		[Test]
		public void When_send_fail_will_raise_error_with_failed_messages_and_exception()
		{
			Exception ex = null;
			TransportMessage[] msgs = null;
			using (sender = new Sender(localStorage, 1))
			{
				sender.Start();
				var resetEvent = new ManualResetEvent(false);
				sender.Error += (e, t) =>
				{
					ex = e;
					msgs = t;
					sender.Dispose();
					resetEvent.Set();
				};
				localStorage.Add("http://localhost/test/", new TransportMessage
				{
					Message = new Message { Value = 1 },
					Destination = new Destination { Queue = "test2" }
				});
				resetEvent.WaitOne();
				localStorage.Dispose();
			}
			localStorage.WaitForNewMessages();
			Assert.IsNotNull(ex);
			Assert.AreEqual(1, msgs.Length);
			Assert.AreEqual(1, msgs[0].Message.Value);
		}
	}
}