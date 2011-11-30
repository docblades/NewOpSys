using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystemSimulation.src.CPU
{
    public struct Registers
    {
        public Int32 ProgramCounter { get; set; }
        public Int32 Accumulator { get; set; }
    }
}
