using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystemSimulation.src.Instructions.Jump
{
    abstract class JumpInstruction : Instruction
    {
        protected UInt32 Address { get; set; } // 24 rightmost bits

        internal void SetupAddress(UInt32 instructionData)
        {
            var query = new InstructionUtility.MaskedInstructionQuery()
            {
                InstructionData = instructionData,
                ShiftPosition = 0,
                BitLength = 24
            };

            Address = InstructionUtility.GetValueFromInstruction(query);
        }

        public abstract void ExecuteInstruction(Process.IProcess myProcess);
    }
}
