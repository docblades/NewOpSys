using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OperatingSystemSimulation.src.Process;

namespace OperatingSystemSimulation.src.CPU
{
    public interface ICPU
    {
        int CPUID { get; }
        int ProcessCount { get; }
        void AddProcess(IProcess process);
        void StartCPU();
        void Shutdown();
    }
}
