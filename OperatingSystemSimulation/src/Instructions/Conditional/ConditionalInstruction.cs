using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystemSimulation.src.Instructions.Conditional
{
    abstract class ConditionalInstruction : Instruction
    {
        public void ExecuteInstruction(Process.IProcess myProcess)
        {
            throw new NotImplementedException();
        }
    }
}
