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
         
        public Int32 GetNewPageNumber(int size)
        {
            PageInfo freePage = GetAFreePage(size);
            return InfoTable.IndexOf(freePage);
        }

        public Int32 read(int pageNum, Int32 offset)
        {
            Int32 realAddress = GetRealAddress(pageNum) + offset;

            return RealMemory.read(realAddress);
        }

        public void write(int pageNum, Int32 offset, Int32 value)
        {
            Int32 realAddress = GetRealAddress(pageNum) + offset;

            RealMemory.write(realAddress, value);
        }

        private Int32 GetRealAddress(int pageNum)
        {
            return InfoTable[pageNum].RealAddress;
        }

        #region newpage helpers
        
        private PageInfo GetAFreePage(int size)
        {
            int neededBlocks = BlocksForSize(size);

            if (InfoTable.Any(page => PageIsUnusedAndBigEnough(page, neededBlocks)))
            {
                return InfoTable.First(page => PageIsUnusedAndBigEnough(page, neededBlocks));
            }
            else
            {
                PageInfo lastPage = InfoTable.Last();
                Int32 nextAvailableAddress = lastPage.RealAddress + lastPage.Size;

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

        private static int BLOCKSIZE = 4;

        private static int BlocksForSize(int size)
        {
            return (int)Math.Ceiling((double)size / (double)BLOCKSIZE);
        }

        private static bool PageIsUnusedAndBigEnough(PageInfo page, int blocks)
        {
            return page.Used == false && page.Size >= blocks * BLOCKSIZE;
        }

        #endregion

        private struct PageInfo
        {
            public Int32 RealAddress { get; set; }
            public Int32 Size { get; set; }
            public bool Used { get; set; }
        }
    }
}
