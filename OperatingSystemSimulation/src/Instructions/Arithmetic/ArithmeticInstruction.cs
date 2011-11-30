using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OperatingSystemSimulation.src.Process;

namespace OperatingSystemSimulation.src.Instructions.Arithmetic
{
    abstract class ArithmeticInstruction : Instruction
    {
        public abstract void ExecuteInstruction(Process.IProcess myProcess);

        protected UInt32 Source1 { get; set; }
        protected UInt32 Source2 { get; set; }
        protected UInt32 Destination { get; set; }
        
        internal void SetupRegisters(UInt32 instructionData)
        {
            Source1 = GetSource1(instructionData);
            Source2 = GetSource2(instructionData);
            Destination = GetDestination(instructionData);
        }

        #region register helpers
        
        private static UInt32 GetSource1(UInt32 instructionData)
        {
            var query = new InstructionUtility.MaskedInstructionQuery()
            {
                InstructionData = instructionData,
                BitLength = 4,
                ShiftPosition = 20
            };

            return InstructionUtility.GetValueFromInstruction(query);
        }

        private static UInt32 GetSource2(UInt32 instructionData)
        {
            var query = new InstructionUtility.MaskedInstructionQuery()
            {
                InstructionData = instructionData,
                BitLength = 4,
                ShiftPosition = 16
            };

            return InstructionUtility.GetValueFromInstruction(query);
        }

        private static UInt32 GetDestination(UInt32 instructionData)
        {
            var query = new InstructionUtility.MaskedInstructionQuery()
            {
                InstructionData = instructionData,
                BitLength = 4,
                ShiftPosition = 12
            };

            return InstructionUtility.GetValueFromInstruction(query);
        }

        #endregion

        protected uint GetSource1Val(IProcess myProcess)
        {
            return myProcess.PCB.ProcessRegisters.GetRegisterValue(Source1);        
        }

        protected uint GetSource2Val(IProcess myProcess)
        {
            return myProcess.PCB.ProcessRegisters.GetRegisterValue(Source2);
        }

        protected void SetDestinationVal(IProcess myProcess, uint value)
        {
            myProcess.PCB.ProcessRegisters.SetRegisterValue(Destination, value);
        }

        protected void ContinueProcessing(IProcess myProcess)
        {
            myProcess.PCB.ProcessRegisters.ProgramCounter += 1;
            myProcess.ContinueCalculating = true;
        }
    }
}
