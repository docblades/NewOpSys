using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystemSimulation.src.Instructions.Arithmetic
{
    class MOV : ArithmeticInstruction
    {
        public override void ExecuteInstruction(Process.IProcess myProcess)
        {
            myProcess.ContinueCalculating = true;

            uint sourceVal = myProcess.PCB.ProcessRegisters.GetRegisterValue(Source1);
            myProcess.PCB.ProcessRegisters.SetRegisterValue(Destination, sourceVal);

            myProcess.PCB.ProcessRegisters.ProgramCounter += 1;
        }
    }
}
