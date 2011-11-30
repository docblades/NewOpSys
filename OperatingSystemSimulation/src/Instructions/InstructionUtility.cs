using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystemSimulation.src.Instructions
{
    class InstructionUtility
    {
        public struct MaskedInstructionQuery
        {
            public UInt32 InstructionData {get;set;}
            public int ShiftPosition {get;set;}
            public int BitLength {get;set;}
        }

        public static UInt32 GetValueFromInstruction(MaskedInstructionQuery query)
        {
            uint bitMask = (uint)Math.Pow(2, query.BitLength) - 1; // length 4U = 1111b or 15U

            uint shiftedValue = query.InstructionData >> query.ShiftPosition;
            uint maskedValue = shiftedValue & bitMask;

            return maskedValue;        
        }
    }
}
