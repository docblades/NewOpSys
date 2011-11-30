using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystemSimulation.src.Instructions.IO
{
    abstract class IOInstruction : Instruction
    {
        public abstract void ExecuteInstruction(Process.IProcess myProcess);

        protected UInt32 Register1 { get; set; }
        protected UInt32 Register2 { get; set; }
        protected UInt32 Address { get; set; }

        internal void SetupAddressAndRegisters(UInt32 instructionData)
        {
            Register1 = GetRegister1(instructionData);
            Register2 = GetRegister2(instructionData);
            Address = GetAddress(instructionData);
        }

        #region register helpers
        
        private static UInt32 GetRegister1(UInt32 instructionData)
        {
            var query = new InstructionUtility.MaskedInstructionQuery()
            {
                InstructionData = instructionData,
                ShiftPosition = 20,
                BitLength = 4
            };

            return InstructionUtility.GetValueFromInstruction(query);
        }

        private static UInt32 GetRegister2(UInt32 instructionData)
        {
            var query = new InstructionUtility.MaskedInstructionQuery()
            {
                InstructionData = instructionData,
                ShiftPosition = 16,
                BitLength = 4
            };

            return InstructionUtility.GetValueFromInstruction(query);
        }

        private static UInt32 GetAddress(UInt32 instructionData)
        {
            var query = new InstructionUtility.MaskedInstructionQuery()
            {
                InstructionData = instructionData,
                ShiftPosition = 0,
                BitLength = 16
            };

            return InstructionUtility.GetValueFromInstruction(query);
        }

        #endregion

        protected void InsertActionIntoDMAQueueAndStopExecution(Process.IProcess myProcess, Memory.DMARequest.MemoryAction action)
        {
            var request = new Memory.DMARequest()
            {
                MyProcess = myProcess,
                MemoryWork = action
            };

            myProcess.ContinueCalculating = false;
            myProcess.PCB.ProcessRegisters.ProgramCounter += 1;

            Sys.System.DMA.InsertRequestInQueue(request);
        }

        protected void InsertActionIntoDMAQueueAndStopExecution(Process.IProcess myProcess, Memory.DMARequest.MemoryAction action, IDictionary<string, uint> extraData)
        {
            var request = new Memory.DMARequest()
            {
                MyProcess = myProcess,
                MemoryWork = action,
                ExtraData = extraData
            };

            myProcess.ContinueCalculating = false;
            myProcess.PCB.ProcessRegisters.ProgramCounter += 1;

            Sys.System.DMA.InsertRequestInQueue(request);
        }

        protected IDictionary<string,uint> GetMetaData()
        {
            return new Dictionary<string, uint>(){
                {"Register1", Register1},
                {"Register2", Register2},
                {"Address", Address}
            };           
        }
    }
}
