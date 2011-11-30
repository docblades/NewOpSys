using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystemSimulation.src.Process
{
    class Process : IProcess
    {
        public ProcessControlBlock PCB { get; set; }

        public bool ContinueCalculating { get; set; }

        public Instructions.Instruction GetNextInstruction()
        {
            throw new NotImplementedException();
        }
    }
}
