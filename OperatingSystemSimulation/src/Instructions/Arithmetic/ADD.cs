using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystemSimulation.src.Instructions.Arithmetic
{
    class ADD : ArithmeticInstruction
    {

        public override void ExecuteInstruction(Process.IProcess myProcess)
        {
            myProcess.ContinueCalculating = true;

            uint source1Val = myProcess.PCB.ProcessRegisters.GetRegisterValue(Source1);
            uint source2Val = myProcess.PCB.ProcessRegisters.GetRegisterValue(Source2);

            uint result = source1Val + source2Val;
            myProcess.PCB.ProcessRegisters.SetRegisterValue(Destination, result);

            myProcess.PCB.ProcessRegisters.ProgramCounter += 1;
        }
    }
}
