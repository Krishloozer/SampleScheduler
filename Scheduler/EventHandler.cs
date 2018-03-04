using Scheduler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Scheduler
{
    public class EventHandler : IEventHandler
    {
        private SchedulerFactory _schedulerFactory;

        public EventHandler() 
        {
            _schedulerFactory = new SchedulerFactory();
        }

        public void HandleStartEvent(string schedulerName, SchedulerType schedulerType, IntervalType intervalType, int interval, RepeatInterval repeatInterval = RepeatInterval.None,int repeatIntervalValue=0)
        {
            ProcessTask(schedulerName);
            var delay = TimerHelper.Getinterval(intervalType, interval);
            var scheduler = _schedulerFactory.New(schedulerName, delay);
            AddEventHandler(scheduler, intervalType, repeatInterval, repeatIntervalValue);
            
        }

        private void AddEventHandler(Scheduler scheduler, IntervalType intervalType,RepeatInterval repeatInterval,int repeatIntervalValue) 
        {
            switch (intervalType)
            {
                case IntervalType.Minutely:
                    {
                        scheduler.Timer.Elapsed += (sender, e) => HandleMinutelyEvent(scheduler.ParentName);
                        break;
                    }
                case IntervalType.Hourly:
                    {
                        scheduler.Timer.Elapsed += (sender, e) => HandleHourlyEvent(scheduler.ParentName, repeatInterval, repeatIntervalValue);
                        break;
                    }
                default: break;
            }
        }


        public void HandleMinutelyEvent(string schedulerName,double delay, bool stopOnTimeOut = false)
        {

            throw new NotImplementedException();
        }

        public void HandleHourlyEvent(string schedulerName, RepeatInterval repeatinterval, int repeatintervalValue, bool stopOnTimeOut = false, DateTime? timeOutTime = null)
        {
            throw new NotImplementedException();
        }

        

        private void ProcessTask(string schedulerName)
        {
            Console.WriteLine("Logging on event triggered by scheduler " + schedulerName + "..." + DateTime.Now);
        }
    }
}
