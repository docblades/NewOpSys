using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystemSimulation.src.Instructions
{
    public interface IInstructionFactory
    {
        bool IsMyInstructionType(UInt32 instructionData);
        Instruction CreateInstruction(UInt32 instructionData);
    }
}
