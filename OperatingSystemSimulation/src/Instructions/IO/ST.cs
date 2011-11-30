using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystemSimulation.src.Instructions.IO
{
    class ST : IOInstruction
    {
        public static void StoreContentsOfFirstRegisterInAddress(Process.IProcess myProcess, IDictionary<string, uint> extraData)
        {
            var value = myProcess.PCB.ProcessRegisters.GetRegisterValue(extraData["registerAddr"]);

            myProcess.PCB.DataArea.write(extraData["destinationAddr"], value);
        }

        public override void ExecuteInstruction(Process.IProcess myProcess)
        {
            var extraData = new Dictionary<string,uint>(){
                {"registerAddr", Register1},
                {"destinationAddr", Address}
            };

            InsertActionIntoDMAQueueAndStopExecution(myProcess, StoreContentsOfFirstRegisterInAddress, extraData);
        }
    }
}
