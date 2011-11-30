using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystemSimulation.src.Instructions.Arithmetic
{
    class ArithmeticInstructionFactory : InstructionFactory, IInstructionFactory
    {
        private uint MyType = 0; // 00b
        public bool IsMyInstructionType(uint instructionData)
        {
            uint instructionType = GetInstructionType(instructionData);
            return instructionType == MyType;
        }

        Instruction IInstructionFactory.CreateInstruction(uint instructionData)
        {
            uint opCode = GetOpCode(instructionData);

            System.Type instructionType = InstructionMap[opCode];
            ArithmeticInstruction instruction = (ArithmeticInstruction)Activator.CreateInstance(instructionType);

            instruction.SetupRegisters(instructionData);

            return instruction;
        }

        private static IDictionary<uint, System.Type> InstructionMap = new Dictionary<uint, System.Type>()
        {
            {(uint)0x13, typeof(NOOP)},
            {(uint)0x04, typeof(MOV)},
            {(uint)0x05, typeof(ADD)},
            {(uint)0x06, typeof(SUB)},
            {(uint)0x07, typeof(MUL)},
            {(uint)0x08, typeof(DIV)},
            {(uint)0x09, typeof(AND)},
            {(uint)0x0A, typeof(OR)}
        };
    }
}
