using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystemSimulation.src.Memory
{
    class RAM : IMemory
    {
        private IList<uint> LocalMem { get; set; }

        public RAM(int size)
        {
            LocalMem = new List<uint>(size);
        }

        public void write(uint address, uint value)
        {
            LocalMem[(int)address] = value;
        }

        public uint read(uint address)
        {
            return LocalMem[(int)address];
        }
    }
}
