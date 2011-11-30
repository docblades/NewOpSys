using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystemSimulation.src.Instructions.Jump
{
    class JMP : JumpInstruction
    {
        public override void ExecuteInstruction(Process.IProcess myProcess)
        {
            JumpToAddressAndContinue(myProcess);
        }

        private void JumpToAddressAndContinue(Process.IProcess myProcess)
        {
            myProcess.ContinueCalculating = true;
            myProcess.PCB.ProcessRegisters.ProgramCounter = (int)Address;
        }
    }
}
