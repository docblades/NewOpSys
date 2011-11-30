﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OperatingSystemSimulation.src.Queues;
using OperatingSystemSimulation.src.Process;

namespace OperatingSystemSimulation.src.CPU
{
    class RoundRobinCPU : ICPU
    {
        private int _cpuID = -1;
        private readonly BlockingQueue<IProcess> ProcessQueue = new BlockingQueue<IProcess>();
        private bool shuttingDown = false;

        public int CPUID
        {
            get { return _cpuID; }
        }

        public int ProcessCount
        {
            get { return ProcessQueue.Count; }
        }

        public void AddProcess(IProcess process)
        {
            ProcessQueue.EnQueue(process);
        }

        public void StartCPU
        {
            get { throw new NotImplementedException(); }
        }

        private void WorkingLoop()
        {
            
        }

        public void Shutdown()
        {
            shuttingDown = true;
            Monitor.PulseAll(ProcessQueue);
        }


    }
}