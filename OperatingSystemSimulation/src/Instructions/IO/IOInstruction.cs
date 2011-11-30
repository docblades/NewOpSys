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

    }
}
