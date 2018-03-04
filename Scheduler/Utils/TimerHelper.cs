using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Scheduler.Utils
{
    public class TimerHelper
    {
        public static Timer GetDefaultMinutelyTimer()
        {
            return GetTimer(DefaultDelay.Minutely);
        }
        public static Timer GetDefaultHourlyTimer()
        {
            return GetTimer(DefaultDelay.Hourly);
        }
        public static Timer GetDefaultDailyTimer()
        {
            return GetTimer(DefaultDelay.Daily);
        }
        public static Timer GetDefaultWeeklyTimer()
        {
            return GetTimer(DefaultDelay.Weekly);
        }

        public static Timer GetTimer(double interval)
        {
            return new Timer
            {
                Enabled = true,
                Interval = interval
            };
        }

        public static Timer GetInitialTimer(DateTime startTime){
            var now = DateTime.Now;
            var dateTimeNow = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0);
            var initialDelay = (startTime - dateTimeNow).TotalMilliseconds;
            return GetTimer(initialDelay);
        }

        public static double Getinterval(IntervalType type, int interval)
        {
            double delay = DefaultDelay.Hourly;
            switch (type)
            {
                case IntervalType.Minutely:
                    {
                        delay = (interval * DefaultDelay.Minutely);
                        break;
                    }
                case IntervalType.Hourly:
                    {
                        delay = (interval * DefaultDelay.Hourly);
                        break;
                    }
                case IntervalType.Daily:
                    {
                        delay = (interval * DefaultDelay.Daily);
                        break;
                    }
                case IntervalType.Weekly:
                    {
                        delay = (interval * DefaultDelay.Weekly);
                        break;
                    }
                default: break;
            }
            return delay;
        }
    }
}
