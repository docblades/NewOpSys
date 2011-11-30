using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystemSimulation.src.Instructions.Arithmetic
{
    class SLT : ArithmeticInstruction
    {
        public override void ExecuteInstruction(Process.IProcess myProcess)
        {
            var source1Val = GetSource1Val(myProcess);
            var source2Val = GetSource2Val(myProcess);

            if (source1Val < source2Val)
                SetDestinationVal(myProcess, 1);
            else
                SetDestinationVal(myProcess, 0);

            ContinueProcessing(myProcess);
        }
    }
}
