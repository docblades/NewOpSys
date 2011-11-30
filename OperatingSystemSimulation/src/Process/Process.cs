using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystemSimulation.src.Process
{
    class Process : IProcess
    {
        public ProcessControlBlock PCB
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool ContinueCalculating
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Instructions.Instruction GetNextInstruction()
        {
            throw new NotImplementedException();
        }
    }
}
