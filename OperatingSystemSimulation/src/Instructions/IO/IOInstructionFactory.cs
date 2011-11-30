using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystemSimulation.src.Instructions.IO
{
    class IOInstructionFactory : InstructionFactory, IInstructionFactory
    {
        private uint MyType = 3; // 11b
        public bool IsMyInstructionType(uint instructionData)
        {
            uint instructionType = GetInstructionType(instructionData);
            return instructionType == MyType;
        }

        Instruction IInstructionFactory.CreateInstruction(uint instructionData)
        {
            uint opCode = GetOpCode(instructionData);

            System.Type instructionType = InstructionMap[opCode];
            IOInstruction instruction = (IOInstruction)Activator.CreateInstance(instructionType);

            instruction.SetupAddressAndRegisters(instructionData);

            return instruction;
        }

        private static IDictionary<uint, System.Type> InstructionMap = new Dictionary<uint, System.Type>()
        {
            {(uint)0x13, typeof(NOOP)},
            {(uint)0x00, typeof(RD)},
            {(uint)0x01, typeof(WR)},
            {(uint)0x02, typeof(ST)},
            {(uint)0x03, typeof(LW)},
            {(uint)0x0F, typeof(LW)}, // I don't see a difference between the requirements for LW and LDI
            {(uint)0x0B, typeof(MOVI)},
            {(uint)0x0C, typeof(ADDI)},
            {(uint)0x0D, typeof(MULI)},
            {(uint)0x0E, typeof(DIVI)},
            {(uint)0x11, typeof(SLTI)}
        };
   
    }
}
