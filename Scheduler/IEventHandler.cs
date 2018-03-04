using Scheduler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Scheduler
{
    public interface IEventHandler
    {
        public void HandleStartEvent(string schedulerName, SchedulerType schedulerType, IntervalType intervalType, int interval, RepeatInterval repeatInterval = RepeatInterval.None, int repeatIntervalValue = 0);
        public void HandleMinutelyEvent(string schedulerName, bool stopOnTimeOut = false, DateTime? timeOutTime = null);
        public void HandleHourlyEvent(string schedulerName, RepeatInterval repeatinterval, int repeatintervalValue, bool stopOnTimeOut = false, DateTime? timeOutTime = null);
    }
}
