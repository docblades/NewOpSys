using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace OperatingSystemSimulation.src.Instructions.IO
{
    class WR : IOInstruction
    {
        public static void WriteFromAccumulatorToOutput(Process.IProcess myProcess, IDictionary<string, uint> extraData)
        {
            var value = myProcess.PCB.ProcessRegisters.GetRegisterValue(CPU.Registers.ACCUMULATORADDRESS);

            var bw = new BinaryWriter(Sys.System.InOutStream);
            bw.Write(value);

        }

        public override void ExecuteInstruction(Process.IProcess myProcess)
        {
            InsertActionIntoDMAQueueAndStopExecution(myProcess, WriteFromAccumulatorToOutput);
        }
    }
}
