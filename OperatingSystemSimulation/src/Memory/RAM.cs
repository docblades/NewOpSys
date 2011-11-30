using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystemSimulation.src.Memory
{
    class RAM : IMemory
    {
        private IList<Int32> LocalMem { get; set; }

        public RAM(int size)
        {
            LocalMem = new List<Int32>(size);
        }

        public void write(int address, int value)
        {
            LocalMem[address] = value;
        }

        public int read(int address)
        {
            return LocalMem[address];
        }
    }
}
