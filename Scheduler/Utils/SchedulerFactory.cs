using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Scheduler.Utils
{
    public class SchedulerFactory
    {

        public Scheduler New(string id, Timer timer, SchedulerType type = SchedulerType.Parent)
        {
            return GetScheduler(id, type, timer);
        }

        private Scheduler GetScheduler(string id, SchedulerType type, Timer timer)
        {
            return new Scheduler
            {
                Id = id,
                Type = type,
                Timer = timer
            };
        }



        public Scheduler Default(IntervalType type = IntervalType.Minutely, int interval = 1)
        {
            var delayInterval = TimerHelper.Getinterval(type, interval);
            return GetScheduler(Guid.NewGuid().ToString(), SchedulerType.Parent, delayInterval);
        }

        public Scheduler New(string id, double intervalDelay, SchedulerType type = SchedulerType.Parent)
        {
            return GetScheduler(id, type, intervalDelay);
        }

        public Scheduler New(string id, SchedulerType schedulerType, IntervalType intervalType = IntervalType.Minutely, int interval = 1)
        {
            var delayInterval = TimerHelper.Getinterval(intervalType, interval);
            return GetScheduler(id, schedulerType, delayInterval);
        }

        private Scheduler GetScheduler(string id, SchedulerType type, double interval)
        {
            return new Scheduler
            {
                Id = id,
                Type = type,
                Timer = TimerHelper.GetTimer(interval)
            };
        }
    }
}
