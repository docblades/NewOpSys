using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystemSimulation.src.Memory
{
    class Page : IMemory
    {
        private PageTable Table { get; set; }
        public int PageNumber { get; set; }

        public Page(PageTable pageTable, uint size)
        {
            Table = pageTable;
            PageNumber = Table.GetNewPageNumber(size);
        }

        public void write(uint address, uint value)
        {
            Table.write(PageNumber, address, value);
        }

        public uint read(uint address)
        {
            return Table.read(PageNumber, address);
        }
    }
}
