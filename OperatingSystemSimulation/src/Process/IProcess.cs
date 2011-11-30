using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OperatingSystemSimulation.src.Instructions;

namespace OperatingSystemSimulation.src.Process
{
    public interface IProcess
    {
        ProcessControlBlock PCB { get; set; }
        bool ContinueCalculating { get; set; }
        Instruction GetNextInstruction();
    }
}
