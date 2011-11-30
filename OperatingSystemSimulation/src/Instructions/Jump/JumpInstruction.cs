using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystemSimulation.src.Instructions.Jump
{
    abstract class JumpInstruction : Instruction
    {
        public abstract void ExecuteInstruction(Process.IProcess myProcess);
    }
}
