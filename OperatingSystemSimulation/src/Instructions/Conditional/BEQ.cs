using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystemSimulation.src.Instructions.Conditional
{
    class BEQ : ConditionalInstruction
    {
        public override void ExecuteInstruction(Process.IProcess myProcess)
        {
            var val1 = GetBaseValue(myProcess);
            var val2 = GetDestinationValue(myProcess);

            bool shouldSwitchToNewAddress = val1 == val2;
            if (shouldSwitchToNewAddress)
                ChangeProgramAddressAndContinueProcessing(myProcess);
            else
                ContinueProcessing(myProcess);
            
        }
    }
}
