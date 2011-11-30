using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystemSimulation.src.Instructions.IO
{
    class LW : IOInstruction
    {
        public static void LoadValueFromAddressIntoFirstRegister(Process.IProcess myProcess, IDictionary<string, uint> extraData)
        {
            var value = myProcess.PCB.DataArea.read(extraData["dataAddress"]);

            myProcess.PCB.ProcessRegisters.SetRegisterValue(extraData["registerAddr"], value);
        }

        public override void ExecuteInstruction(Process.IProcess myProcess)
        {
            var extraData = new Dictionary<string, uint>()
            {
                {"dataAddress", Address},
                {"registerAddr", Register1}
            };

            InsertActionIntoDMAQueueAndStopExecution(myProcess, LoadValueFromAddressIntoFirstRegister, extraData);
        }
    }
}
