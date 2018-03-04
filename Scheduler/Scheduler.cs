using Scheduler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Scheduler
{
    public class Scheduler
    {
        public string Id { get; set; }
        public string ParentName { get; set; }
        public string ChildName { get; set; }
        public SchedulerType Type { get; set; }
        public Timer Timer { get; set; }
    }
}
