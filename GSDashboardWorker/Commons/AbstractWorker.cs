using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;

namespace DashboardWorker.Commons
{
    abstract class AbstractWorker : IWorker
    {
        protected MessageQueue messageQueue;

        public AbstractWorker(string QUEUE_ADDRESS, string QUEUE_MULTICAST_ADDRESS, string QUEUE_LABEL)
        {
            if (!MessageQueue.Exists(QUEUE_ADDRESS))
                MessageQueue.Create(QUEUE_ADDRESS);

            messageQueue = new MessageQueue(QUEUE_ADDRESS);
            messageQueue.MulticastAddress = QUEUE_MULTICAST_ADDRESS;
            messageQueue.Label = QUEUE_LABEL;
            messageQueue.Formatter = new XmlMessageFormatter(new String[] { "System.Int32,mscorlib" });
        }

        abstract public void ExecuteWorker();
    }
}
