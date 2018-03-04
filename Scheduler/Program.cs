using Scheduler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Scheduler
{
    class Program
    {
        private static SchedulerManager _schedulerManager;
        private static SchedulerFactory _schedulerFactory;
        private static EventHandler _eventHandler;

        static void Main(string[] args)
        {
            _schedulerManager = SchedulerManager.GetInstance();
            _eventHandler = new EventHandler();

        }

        public static void ScheduleJob(string id, DateTime startTime, IntervalType intervalType, int interval=1)
        {
            var startTimer = TimerHelper.GetInitialTimer(startTime);
            var scheduler = _schedulerFactory.New(id, startTimer);
            scheduler.Timer.Elapsed += (sender, e) => _eventHandler.HandleStartEvent(id, SchedulerType.Parent, intervalType, interval);
        }
        
    }
}
