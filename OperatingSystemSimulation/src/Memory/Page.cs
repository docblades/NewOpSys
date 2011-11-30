using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystemSimulation.src.Memory
{
    class Page : IMemory
    {
        private PageTable Table { get; set; }
        public Int32 PageNumber { get; set; }

        public Page(PageTable pageTable, Int32 size)
        {
            Table = pageTable;
            PageNumber = Table.GetNewPageNumber(size);
        }

        public void write(int address, int value)
        {
            Table.write(PageNumber, address, value);
        }

        public int read(int address)
        {
            return Table.read(PageNumber, address);
        }
    }
}
