using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystemSimulation.src.Instructions.IO
{
    class MOVI : IOInstruction
    {
        public static void MoveDataFromAddressIntoFirstRegister(Process.IProcess myProcess, IDictionary<string, uint> context)
        {
            var value = myProcess.PCB.DataArea.read(context["Address"]);

            myProcess.PCB.ProcessRegisters.SetRegisterValue(context["Register1"], value);
        }

        public override void ExecuteInstruction(Process.IProcess myProcess)
        {
            var context = GetMetaData();

            InsertActionIntoDMAQueueAndStopExecution(myProcess, MoveDataFromAddressIntoFirstRegister, context);
        }
    }
}
