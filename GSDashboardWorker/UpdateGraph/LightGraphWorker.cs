using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DashboardWorker.Commons;
using System.Messaging;

namespace DashboardWorker.UpdateGraph
{
    class LightGraphWorker : AbstractWorker
    {
        protected static string QUEUE_ADDRESS = @".\Private$\LightGraphQueue";
        protected static string QUEUE_MULTICAST_ADDRESS = @"234.1.1.1:8001";
        protected static string QUEUE_LABEL = @"Dashboard Light Processing";

        public LightGraphWorker() : base(QUEUE_ADDRESS, QUEUE_MULTICAST_ADDRESS, QUEUE_LABEL)
        {

        }

        public override void ExecuteWorker()
        {
            while (true)
            {
                Message message = messageQueue.Receive();
                Console.WriteLine("[" + this.GetType().ToString() + "] Recibido:" + message.Body + ". Almacenamiento en bruto de la información.");
            }
        }
    }
}
