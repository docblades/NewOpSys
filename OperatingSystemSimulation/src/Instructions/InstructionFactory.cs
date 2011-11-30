using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystemSimulation.src.Instructions
{
    public abstract class InstructionFactory
    {
        private static IList<IInstructionFactory> Factories = new List<IInstructionFactory>()
        {
            new Arithmetic.ArithmeticInstructionFactory(),
            new Conditional.ConditionalInstructionFactory(),
            new IO.IOInstructionFactory(),
            new Jump.JumpInstructionFactory(),
            new ExceptionInstructionFactory()
        };

        public static Instruction CreateInstruction(UInt32 instructionData)
        {
            IInstructionFactory factory = Factories.First(fact => fact.IsMyInstructionType(instructionData));
            return factory.CreateInstruction(instructionData);
        }

        private static UInt32 INSTRUCTIONTYPEMASK = (uint)3221225472U;
        protected static UInt32 GetInstructionType(UInt32 instructionData)
        {
            const int instructionTypeShift = 30;

            UInt32 maskedType = instructionData & INSTRUCTIONTYPEMASK;
            UInt32 shiftedType = maskedType >> instructionTypeShift;

            return shiftedType;
        }

        private static UInt32 OPCODEMASK = (uint)1056964608U;
        protected static UInt32 GetOpCode(UInt32 instructionData)
        {
            const int opcodeShift = 24;

            UInt32 maskedOpCode = instructionData & OPCODEMASK;
            UInt32 ShiftedOpCode = maskedOpCode >> opcodeShift;

            return ShiftedOpCode;
        }
    }
}
