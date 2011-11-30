using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OperatingSystemSimulation.src.Process;

namespace OperatingSystemSimulation.src.Instructions
{
    public interface Instruction
    {
        void ExecuteInstruction(IProcess myProcess);
    }
}
