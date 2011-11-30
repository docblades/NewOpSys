using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace OperatingSystemSimulation.src.Instructions.IO
{
    class RD : IOInstruction
    {
        public static void ReadFromInput(Process.IProcess myProcess, IDictionary<string, uint> extraData)
        {
            var br = new BinaryReader(Sys.System.InOutStream);
            UInt32 inputValue = br.ReadUInt32();

            myProcess.PCB.ProcessRegisters.SetRegisterValue(CPU.Registers.ACCUMULATORADDRESS, inputValue);
        }

        public override void ExecuteInstruction(Process.IProcess myProcess)
        {
            InsertActionIntoDMAQueueAndStopExecution(myProcess, ReadFromInput);
        }
    }
}
