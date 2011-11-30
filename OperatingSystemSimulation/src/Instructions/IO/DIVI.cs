using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystemSimulation.src.Instructions.IO
{
    class DIVI : IOInstruction
    {
        public static void DivideRegister1ByDataAtAddressInPlace(Process.IProcess myprocess, IDictionary<string, uint> context)
        {
            var register1Value = myprocess.PCB.ProcessRegisters.GetRegisterValue(context["Register1"]);
            var dataValue = myprocess.PCB.DataArea.read(context["Address"]);

            var value = register1Value / dataValue;

            myprocess.PCB.ProcessRegisters.SetRegisterValue(context["Register1"], value);
        }

        public override void ExecuteInstruction(Process.IProcess myProcess)
        {
            var context = GetMetaData();

            InsertActionIntoDMAQueueAndStopExecution(myProcess, DivideRegister1ByDataAtAddressInPlace, context);
        }
    }
}
