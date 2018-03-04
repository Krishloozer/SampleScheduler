using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Utils
{
    public enum IntervalType
    {
        Minutely = 0,
        Hourly = 1,
        Daily = 2,
        Weekly = 3,
        Monthly = 4
    }

    public static class DefaultDelay
    {
        public const double Minutely = (60 * 1000);
        public const double Hourly = (60 * 60 * 1000);
        public const double Daily = (24 * 60 * 60 * 1000);
        public const double Weekly = (24 * 7 * 60 * 60 * 1000);
    }

    public enum SchedulerType
    {
        Parent = 0,
        Child = 1
    }

    public enum RepeatInterval
    {
        None = 0,
        InMinute = 1,
        InHour = 2,
        InDay = 3,
        InWeek = 4
    }
}
