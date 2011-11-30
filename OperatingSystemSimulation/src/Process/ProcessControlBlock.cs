using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OperatingSystemSimulation.src.CPU;
using OperatingSystemSimulation.src.Memory;

namespace OperatingSystemSimulation.src.Process
{
    public struct ProcessControlBlock
    {
        public Registers ProcessRegisters { get; set; }
        public IMemory ProgramData { get; set; }
        public IMemory DataArea { get; set; }
    }
}
