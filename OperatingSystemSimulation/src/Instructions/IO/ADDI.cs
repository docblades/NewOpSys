using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystemSimulation.src.Instructions.IO
{
    class ADDI : IOInstruction
    {
        public static void AddValueAtAddressToRegister1InPlace(Process.IProcess myprocess, IDictionary<string,uint> context)
        {
            var dataValue = myprocess.PCB.DataArea.read(context["Address"]);
            var register1Value = myprocess.PCB.ProcessRegisters.GetRegisterValue(context["Register1"]);

            var value = dataValue + register1Value;

            myprocess.PCB.ProcessRegisters.SetRegisterValue(context["Register1"], value);
        }

        public override void ExecuteInstruction(Process.IProcess myProcess)
        {
            var context = GetMetaData();

            InsertActionIntoDMAQueueAndStopExecution(myProcess, AddValueAtAddressToRegister1InPlace, context);
        }
    }
}
