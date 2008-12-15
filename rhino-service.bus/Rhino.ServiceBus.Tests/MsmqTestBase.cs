using System;
using System.Messaging;
using Rhino.ServiceBus.Impl;
using Rhino.ServiceBus.Internal;
using Rhino.ServiceBus.Msmq;
using Rhino.ServiceBus.Serializers;

namespace Rhino.ServiceBus.Tests
{
    public class MsmqTestBase : IDisposable
    {
        protected readonly Uri ErrorQueueUri;
        private readonly string errorTestQueuePath;

        private readonly string subbscriptionQueuePath;
        protected readonly Uri SubscriptionsUri;

        private readonly string managementQueuePath;
        protected readonly Uri ManagementUri;

        private readonly string managementQueuePath2;
        protected readonly Uri ManagementUri2;

        protected readonly string testQueuePath;
        protected readonly Uri TestQueueUri;

        protected readonly string testQueuePath2;
        protected readonly Uri TestQueueUri2;

        protected readonly string transactionalTestQueuePath;
        protected readonly Uri TransactionalTestQueueUri;

        protected MessageQueue errorQueue;
        protected MessageQueue queue;
        protected MessageQueue subscriptions;
        protected MessageQueue management;
        protected MessageQueue transactionalQueue;

        private ITransport transactionalTransport;
        private ITransport transport;
        protected readonly MessageQueue testQueue2;
        protected readonly MessageQueue management2;

        public MsmqTestBase()
        {
            ManagementUri = new Uri("msmq://./test_queue_management");
            managementQueuePath = MsmqUtil.GetQueueDescription(ManagementUri).QueuePath;

            ManagementUri2 = new Uri("msmq://./test_queue2_management");
            managementQueuePath2 = MsmqUtil.GetQueueDescription(ManagementUri2).QueuePath;

            ErrorQueueUri = new Uri("msmq://./test_queue_error");
            errorTestQueuePath = MsmqUtil.GetQueueDescription(ErrorQueueUri).QueuePath;

            TestQueueUri = new Uri("msmq://./test_queue");
            testQueuePath = MsmqUtil.GetQueueDescription(TestQueueUri).QueuePath;

            TestQueueUri2 = new Uri("msmq://./test_queue2");
            testQueuePath2 = MsmqUtil.GetQueueDescription(TestQueueUri2).QueuePath;

            TransactionalTestQueueUri = new Uri("msmq://./transactional_test_queue");
            transactionalTestQueuePath = MsmqUtil.GetQueueDescription(TransactionalTestQueueUri).QueuePath;

            SubscriptionsUri = new Uri("msmq://./test_subscriptions");
            subbscriptionQueuePath = MsmqUtil.GetQueueDescription(SubscriptionsUri).QueuePath;

            if (MessageQueue.Exists(testQueuePath) == false)
                MessageQueue.Create(testQueuePath);

            if (MessageQueue.Exists(testQueuePath2) == false)
                MessageQueue.Create(testQueuePath2);

            if (MessageQueue.Exists(errorTestQueuePath) == false)
                MessageQueue.Create(errorTestQueuePath);

            if (MessageQueue.Exists(transactionalTestQueuePath) == false)
                MessageQueue.Create(transactionalTestQueuePath, true);

            if (MessageQueue.Exists(subbscriptionQueuePath) == false)
                MessageQueue.Create(subbscriptionQueuePath, true);

            if (MessageQueue.Exists(managementQueuePath) == false)
                MessageQueue.Create(managementQueuePath, true);

            if (MessageQueue.Exists(managementQueuePath2) == false)
                MessageQueue.Create(managementQueuePath2, true);

            queue = new MessageQueue(testQueuePath);
            queue.Purge();

            testQueue2 = new MessageQueue(testQueuePath2);
            testQueue2.Purge();

            management = new MessageQueue(managementQueuePath);
            management.Purge();

            management2 = new MessageQueue(managementQueuePath2);
            management2.Purge();

            errorQueue = new MessageQueue(errorTestQueuePath);
            var filter = new MessagePropertyFilter();
            filter.SetAll();
            errorQueue.MessageReadPropertyFilter = filter;
            errorQueue.Purge();

            transactionalQueue = new MessageQueue(transactionalTestQueuePath);
            transactionalQueue.Purge();

            subscriptions = new MessageQueue(subbscriptionQueuePath)
            {
                Formatter = new XmlMessageFormatter(new[] {typeof (string)})
            };
            subscriptions.Purge();
        }

        public ITransport Transport
        {
            get
            {
                if (transport == null)
                {
                    transport = new MsmqTransport(new JsonSerializer(new DefaultReflection()), TestQueueUri,
                                                  SubscriptionsUri, ErrorQueueUri, 1, 5);
                    transport.Start();
                }
                return transport;
            }
        }

        public ITransport TransactionalTransport
        {
            get
            {
                if (transactionalTransport == null)
                {
                    transactionalTransport = new MsmqTransport(new JsonSerializer(new DefaultReflection()),
                                                               TransactionalTestQueueUri,
                                                               SubscriptionsUri, ErrorQueueUri, 1, 5);
                    transactionalTransport.Start();
                }
                return transactionalTransport;
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            queue.Dispose();
            errorQueue.Dispose();
            transactionalQueue.Dispose();

            if (transport != null)
                transport.Stop();
            if (transactionalTransport != null)
                transactionalTransport.Stop();
        }

        #endregion
    }
}