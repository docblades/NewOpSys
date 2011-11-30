using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystemSimulation.src.Instructions
{
    class ExceptionInstructionFactory : IInstructionFactory
    {
        public bool IsMyInstructionType(uint instructionData)
        {
            return true;
        }

        public Instruction CreateInstruction(uint instructionData)
        {
            throw new ArgumentException("Not a recognized instruction type");
        }
    }
}
