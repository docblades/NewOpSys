using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystemSimulation.src.Instructions.Conditional
{
    class BLZ : ConditionalInstruction
    {
        public override void ExecuteInstruction(Process.IProcess myProcess)
        {
            var val = GetBaseValue(myProcess);

            bool shouldChangeToNewAddress = val < 0;
            if (shouldChangeToNewAddress)
                ChangeProgramAddressAndContinueProcessing(myProcess);
            else
                ContinueProcessing(myProcess);
        }
    }
}
