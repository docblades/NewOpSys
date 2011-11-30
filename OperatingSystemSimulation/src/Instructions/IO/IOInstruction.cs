using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystemSimulation.src.Instructions.IO
{
    abstract class IOInstruction : Instruction
    {
        public void ExecuteInstruction(Process.IProcess myProcess)
        {
            throw new NotImplementedException();
        }
    }
}
