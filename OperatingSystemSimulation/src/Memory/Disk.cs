using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace OperatingSystemSimulation.src.Memory
{
    class Disk : IMemory
    {
        Stream FileStream { get; set; }

        public Disk(string fileName)
        {
            FileStream = File.Open(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);
        }

        public void write(uint address, uint value)
        {
            BinaryWriter writer = new BinaryWriter(FileStream);
            writer.Seek((int)address, SeekOrigin.Begin);
            writer.Write(value);
        }

        public uint read(uint address)
        {
            BinaryReader reader = new BinaryReader(FileStream);
            reader.BaseStream.Seek(address, SeekOrigin.Begin);

            return reader.ReadUInt32();
        }
    }
}
