using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystemSimulation.src.Instructions.Arithmetic
{
    class MUL : ArithmeticInstruction
    {
        public override void ExecuteInstruction(Process.IProcess myProcess)
        {
            var val1 = GetSource1Val(myProcess);
            var val2 = GetSource2Val(myProcess);

            uint result = val1 * val2;
            SetDestinationVal(myProcess, result);

            ContinueProcessing(myProcess);
        }
    }
}
