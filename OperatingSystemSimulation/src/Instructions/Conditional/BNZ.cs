using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystemSimulation.src.Instructions.Conditional
{
    class BNZ : ConditionalInstruction
    {
        public override void ExecuteInstruction(Process.IProcess myProcess)
        {
            var val = GetBaseValue(myProcess);

            bool shouldSwitchToNewAddress = val != 0;
            if (shouldSwitchToNewAddress)
                ChangeProgramAddressAndContinueProcessing(myProcess);
            else
                ContinueProcessing(myProcess);
        }
    }
}
