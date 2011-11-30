using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystemSimulation.src.Memory
{
    public interface IMemory
    {
        public void write(Int32 address, Int32 value);
        public Int32 read(Int32 address);
    }
}
