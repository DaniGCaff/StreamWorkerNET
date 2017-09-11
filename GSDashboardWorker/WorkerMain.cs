using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;
using System.Threading;
using DashboardWorker.UpdateGraph;
using DashboardWorker.Commons;

namespace GSDashboardWorker
{
    class WorkerMain
    {

        static void Main(string[] args)
        {

            List<IWorker> workersList = new List<IWorker>();

            HeavyGraphWorker heavyWorker = new HeavyGraphWorker();
            LightGraphWorker lightWorker = new LightGraphWorker();

            workersList.Add(heavyWorker);
            workersList.Add(lightWorker);

            foreach(IWorker worker in workersList)
            {
                Thread hilo = new Thread(() =>
                {
                    worker.ExecuteWorker();
                });
                hilo.Start();
            }
        }
    }
}
