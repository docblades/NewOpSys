using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OperatingSystemSimulation.src.Process;

namespace OperatingSystemSimulation.src.Memory
{
    public class DMARequest
    {
        public IProcess MyProcess { get; set; }
        public MemoryAction MemoryWork { get; set; }
        public IDictionary<string, uint> ExtraData { get; set; }

        public delegate void MemoryAction(IProcess myProcess, IDictionary<string, uint> extraData);

        public void ExecuteMemoryAction()
        {
            MemoryWork(MyProcess, ExtraData);
            ReinsertProcessInScheduler();
        }

        private void ReinsertProcessInScheduler()
        {
            Sys.System.GetScheduler().ScheduleProcess(MyProcess);
        }
        
    }
}
