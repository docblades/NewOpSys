using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OperatingSystemSimulation.src.Process;
using OperatingSystemSimulation.src.Queues;
using System.Threading;

namespace OperatingSystemSimulation.src.CPU
{
    class CPU_Thread
    {
        int CPUID { get; set; }
        private readonly BlockingQueue<IProcess> ProcessQueue = new BlockingQueue<IProcess>();

        private void WorkLoop()
        {
            
        }

        public void StartCPU()
        {
            throw new NotImplementedException();
        }
    }
}
