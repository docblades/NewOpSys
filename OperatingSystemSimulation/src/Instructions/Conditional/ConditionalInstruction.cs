using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OperatingSystemSimulation.src.Process;

namespace OperatingSystemSimulation.src.Instructions.Conditional
{
    abstract class ConditionalInstruction : Instruction
    {
        public abstract void ExecuteInstruction(Process.IProcess myProcess);

        protected UInt32 Base { get; set; }
        protected UInt32 Destination { get; set; }
        protected UInt32 Address { get; set; }

        internal void SetupRegistersAndAddress(UInt32 instructionData)
        {
            Base = GetBaseRegister(instructionData);
            Destination = GetDestinationRegister(instructionData);
            Address = GetAddress(instructionData);
        }

        #region register helpers

        private static UInt32 GetBaseRegister(UInt32 instructionData)
        {
            var query = new InstructionUtility.MaskedInstructionQuery()
            {
                InstructionData = instructionData,
                ShiftPosition = 20,
                BitLength = 4
            };

            return InstructionUtility.GetValueFromInstruction(query);
        }

        private static UInt32 GetDestinationRegister(UInt32 instructionData)
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

        protected uint GetBaseValue(IProcess myProcess)
        {
            return myProcess.PCB.ProcessRegisters.GetRegisterValue(Base);
        }

        protected uint GetDestinationValue(IProcess myProcess)
        {
            return myProcess.PCB.ProcessRegisters.GetRegisterValue(Destination);
        }

        protected void ChangeProgramAddressAndContinueProcessing(IProcess myProcess)
        {
            myProcess.ContinueCalculating = true;
            myProcess.PCB.ProcessRegisters.ProgramCounter = (int)Address;
        }

        protected void ContinueProcessing(IProcess myProcess)
        {
            myProcess.ContinueCalculating = true;
            myProcess.PCB.ProcessRegisters.ProgramCounter += 1;
        }

    }
}
