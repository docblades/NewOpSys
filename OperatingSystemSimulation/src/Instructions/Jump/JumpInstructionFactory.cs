using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystemSimulation.src.Instructions.Jump
{
    class JumpInstructionFactory : InstructionFactory, IInstructionFactory
    {
        private UInt32 MyType = 2; // 10b
        public bool IsMyInstructionType(uint instructionData)
        {
            uint instructionType = GetInstructionType(instructionData);
            return instructionType == MyType;
        }

        Instruction IInstructionFactory.CreateInstruction(uint instructionData)
        {
            uint opCode = GetOpCode(instructionData);

            System.Type instructionType = InstructionMap[opCode];
            JumpInstruction instruction = (JumpInstruction)Activator.CreateInstance(instructionType);

            instruction.SetupAddress(instructionData);

            return instruction;
        }

        private static IDictionary<uint, System.Type> InstructionMap = new Dictionary<uint, System.Type>()
        {
            {(uint)0x13,  typeof(NOOP)},
            {(uint)0x12, typeof(HLT)}
        };

    }
}
