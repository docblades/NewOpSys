using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystemSimulation.src.Instructions.Jump
{
    class HLT : JumpInstruction
    {

        public override void ExecuteInstruction(Process.IProcess myProcess)
        {
            myProcess.ContinueCalculating = false;            
        }
    }
}
