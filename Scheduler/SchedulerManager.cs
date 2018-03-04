using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    public class SchedulerManager
    {
        private static SchedulerManager _schedulerManager;
        private static List<Scheduler> _schedulers = new List<Scheduler>();
        private SchedulerManager(){}
        public static SchedulerManager GetInstance()
        {
            return _schedulerManager = _schedulerManager ?? new SchedulerManager();
        }

        public void Add(Scheduler scheduler)
        {
            _schedulers.Add(scheduler);
        }

        public void Update(string schedulerid, double delay)
        {
            _schedulers.ForEach(x =>
            {
                if(x.Id == schedulerid)
                {
                    x.Timer.Interval = delay;
                }
            });
        }

        public void Update(string parentName, double delay)
        {
            _schedulers.ForEach(x =>
            {
                if (x.ParentName == parentName)
                {
                    x.Timer.Interval = delay;
                }
            });
        }

        public void UpdateChild(string schedulerid, double delay)
        {
            _schedulers.ForEach(x =>
            {
                if(x.Id.Contains(schedulerid))
                {
                    x.Timer.Interval = delay;
                }
            });
        }

        public void UpdateChild(string childName, double delay)
        {
            _schedulers.ForEach(x =>
            {
                if (x.ChildName == childName)
                {
                    x.Timer.Interval = delay;
                }
            });
        }

        public void Remove(string schedulerId)
        {
            _schedulers.RemoveAll(x => x.Id == schedulerId);
        }

        public void RemoveChild(string schedulerId)
        {
            _schedulers.RemoveAll(x => x.Id.Contains(schedulerId));
        }

        public Scheduler GetSchedulerById(string id)
        {
            return _schedulers.FirstOrDefault(x => x.Id == id);
        }

        public Scheduler GetSchedulerByParent(string parentName)
        {
            return _schedulers.FirstOrDefault(x => x.ParentName == parentName);
        }

        public Scheduler GetSchedulerByChild(string childName)
        {
            return _schedulers.FirstOrDefault(x => x.ChildName == childName);
        }
    }
}
