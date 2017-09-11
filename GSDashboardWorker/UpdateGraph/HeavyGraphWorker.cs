using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DashboardWorker.Commons;
using System.Messaging;

namespace DashboardWorker.UpdateGraph
{
    class HeavyGraphWorker : AbstractWorker
    {
        protected static string QUEUE_ADDRESS = @".\Private$\HeavyGraphQueue";
        protected static string QUEUE_MULTICAST_ADDRESS = @"234.1.1.1:8001";
        protected static string QUEUE_LABEL = @"Dashboard Heavy Processing";

        public HeavyGraphWorker() : base(QUEUE_ADDRESS, QUEUE_MULTICAST_ADDRESS, QUEUE_LABEL)
        {

        }

        public override void ExecuteWorker()
        {
            while(true)
            {
                Message message = messageQueue.Receive();
                Console.WriteLine("[" + this.GetType().ToString() + "] Recibido:" + message.Body + ". Lanzamiento de subproceso que hace operaciones de Agg.");
            }
        }        
    }
}
