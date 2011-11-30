using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystemSimulation.src.Instructions.Conditional
{
    class NOOP : ConditionalInstruction
    {

        public override void ExecuteInstruction(Process.IProcess myProcess)
        {
            myProcess.ContinueCalculating = true;
            myProcess.PCB.ProcessRegisters.ProgramCounter += 1;
        }
    }
}
