using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystemSimulation.src.Instructions.Conditional
{
    class ConditionalInstructionFactory : InstructionFactory, IInstructionFactory
    {
        private uint MyType = 1; // 01b
        public bool IsMyInstructionType(uint instructionData)
        {
            uint instructionType = GetInstructionType(instructionData);
            return instructionType == MyType;
        }

        Instruction IInstructionFactory.CreateInstruction(uint instructionData) 
        {
            uint opCode = GetOpCode(instructionData);

            System.Type instructionType = InstructionMap[opCode];
            ConditionalInstruction instruction = (ConditionalInstruction)Activator.CreateInstance(instructionType);

            instruction.SetupRegistersAndAddress(instructionData);

            return instruction;
        }

        private static IDictionary<uint, System.Type> InstructionMap = new Dictionary<uint, System.Type>()
        {
            {(uint)0x13, typeof(NOOP)},
            {(uint)0x15, typeof(BEQ)},
            {(uint)0x16, typeof(BNE)},
            {(uint)0x17, typeof(BEZ)},
            {(uint)0x18, typeof(BNZ)},
            {(uint)0x19, typeof(BGZ)},
            {(uint)0x20, typeof(BLZ)}
        };

    }
}
