using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OperatingSystemSimulation.src.Process;

namespace OperatingSystemSimulation.src.CPU
{
    public interface ICPU
    {
        public int CPUID { get; }
        public int ProcessCount { get; }
        public void AddProcess(IProcess process);
        public void StartCPU { get; }
        public void Shutdown();
    }
}
