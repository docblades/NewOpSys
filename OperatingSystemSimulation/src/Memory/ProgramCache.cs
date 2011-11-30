using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OperatingSystemSimulation.src.Instructions;

namespace OperatingSystemSimulation.src.Memory
{
    class ProgramCache : IMemory
    {
        IList<Int32> programMemory;

        public ProgramCache(int programSize)
        {
            programMemory = new List<Int32>(programSize);
        }

        public void write(int address, int value)
        {
            programMemory[address] = value;
        }

        public int read(int address)
        {
            return programMemory[address];
        }

        public Instruction GetInstruction(Int32 programCounter)
        {
            UInt32 instructionData = (UInt32)read(programCounter);

            return InstructionFactory.CreateInstruction(instructionData);     
        }
    }
}
