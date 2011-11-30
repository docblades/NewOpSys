using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystemSimulation.src.Memory
{
    class PageTable
    {
        private IMemory RealMemory { get; set; }
        private IList<PageInfo> InfoTable = new List<PageInfo>();

        public PageTable(IMemory realMemory)
        {
            RealMemory = realMemory;
        }
         
        public int GetNewPageNumber(uint size)
        {
            PageInfo freePage = GetAFreePage(size);
            return InfoTable.IndexOf(freePage);
        }

        public uint read(int pageNum, uint offset)
        {
            uint realAddress = GetRealAddress(pageNum) + offset;

            return RealMemory.read(realAddress);
        }

        public void write(int pageNum, uint offset, uint value)
        {
            uint realAddress = GetRealAddress(pageNum) + offset;

            RealMemory.write(realAddress, value);
        }

        private uint GetRealAddress(int pageNum)
        {
            return InfoTable[pageNum].RealAddress;
        }

        #region newpage helpers
        
        private PageInfo GetAFreePage(uint size)
        {
            uint neededBlocks = BlocksForSize(size);

            if (InfoTable.Any(page => PageIsUnusedAndBigEnough(page, neededBlocks)))
            {
                return InfoTable.First(page => PageIsUnusedAndBigEnough(page, neededBlocks));
            }
            else
            {
                PageInfo lastPage = InfoTable.Last();
                uint nextAvailableAddress = lastPage.RealAddress + lastPage.Size;

                PageInfo newPage = new PageInfo()
                    {
                        RealAddress = nextAvailableAddress,
                        Size = neededBlocks * BLOCKSIZE,
                        Used = true
                    };

                InfoTable.Add(newPage);

                return newPage;
            }             
        }

        private static uint BLOCKSIZE = 4;

        private static uint BlocksForSize(uint size)
        {
            return (uint)Math.Ceiling((double)size / (double)BLOCKSIZE);
        }

        private static bool PageIsUnusedAndBigEnough(PageInfo page, uint blocks)
        {
            return page.Used == false && page.Size >= blocks * BLOCKSIZE;
        }

        #endregion

        private struct PageInfo
        {
            public uint RealAddress { get; set; }
            public uint Size { get; set; }
            public bool Used { get; set; }
        }
    }
}
