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

        public void write(int address, int value)
        {
            BinaryWriter writer = new BinaryWriter(FileStream);
            writer.Seek(address, SeekOrigin.Begin);
            writer.Write(value);
        }

        public int read(int address)
        {
            BinaryReader reader = new BinaryReader(FileStream);
            reader.BaseStream.Seek(address, SeekOrigin.Begin);

            return reader.ReadInt32();
        }
    }
}
