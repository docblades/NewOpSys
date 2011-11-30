using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystemSimulation.src.Sys
{
    public class Scheduler
    {
        public IList<CPU.ICPU> AvailableCPUs { get; set; }

        private int LastCPUUsed { get; set; } 

        internal void StartAllCPUs()
        {
            foreach (var cpu in AvailableCPUs)
            {
                cpu.StartCPU();
            }
        }

        private void IncrementCPU()
        {
            LastCPUUsed += 1;
            if (LastCPUUsed >= AvailableCPUs.Count)
                LastCPUUsed = 0;
        }

        public void ScheduleProcess(Process.IProcess process)
        {
            IncrementCPU();
            CPU.ICPU currentCPU = AvailableCPUs[LastCPUUsed];
            currentCPU.AddProcess(process);
        }
    }
}
