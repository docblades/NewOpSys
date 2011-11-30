using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystemSimulation.src.Memory
{
    public interface IMemory
    {
        void write(uint address, uint value);
        uint read(uint address);
    }
}
