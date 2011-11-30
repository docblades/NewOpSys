using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace OperatingSystemSimulation.src.Sys
{
    public class System
    {
        private static Scheduler SchedulerSingleton { get; set; }
        public static Scheduler GetScheduler()
        {
            if (SchedulerSingleton == null)
                SchedulerSingleton = new Scheduler();

            return SchedulerSingleton;
        }

        internal static void SetScheduler(Scheduler scheduler)
        {
            if (SchedulerSingleton != null)
                return;

            SchedulerSingleton = scheduler;
        }

        public static Stream InOutStream { get; set; }

        public static Memory.DMAThread DMA { get; set; } 

    }
}
