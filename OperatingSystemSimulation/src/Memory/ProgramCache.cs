using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OperatingSystemSimulation.src.Instructions;

namespace OperatingSystemSimulation.src.Memory
{
    class ProgramCache : IMemory
    {
        IList<uint> programMemory;

        public ProgramCache(int programSize)
        {
            programMemory = new List<uint>(programSize);
        }

        public void write(uint address, uint value)
        {
            programMemory[(int)address] = value;
        }

        public uint read(uint address)
        {
            return programMemory[(int)address];
        }

        public Instruction GetInstruction(uint programCounter)
        {
            UInt32 instructionData = (UInt32)read(programCounter);

            return InstructionFactory.CreateInstruction(instructionData);     
        }
    }
}
