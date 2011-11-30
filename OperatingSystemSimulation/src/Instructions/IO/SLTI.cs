using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystemSimulation.src.Instructions.IO
{
    class SLTI : IOInstruction
    {
        public static void SetSecondRegisterValueTo1IfLessThanDataValue0Otherwise(Process.IProcess myprocess, IDictionary<string, uint> context)
        {           
            var dataValue = myprocess.PCB.DataArea.read(context["Address"]);
            var reg1Value = myprocess.PCB.ProcessRegisters.GetRegisterValue(context["Register1"]);

            uint value = 0;
            if (reg1Value < dataValue)
                value = 1;

            myprocess.PCB.ProcessRegisters.SetRegisterValue(context["Register2"], value);
        }

        public override void ExecuteInstruction(Process.IProcess myProcess)
        {
            throw new NotImplementedException();
        }
    }
}
