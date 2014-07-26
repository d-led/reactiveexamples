using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfrxexample.ViewModels
{
    public class BackgroundTicker
    {
        IScheduler scheduler = Scheduler.Default;

        public BackgroundTicker(IScheduler other_scheduler = null)
        {
            if (other_scheduler != null)
                scheduler = other_scheduler;
        }

        public IObservable<string> Ticker
        {
            get
            {
                return Observable
                    .Interval(TimeSpan.FromSeconds(1), scheduler)
                    .Select(_ => DateTime.Now.ToLongTimeString());
            }
        }
    }
}
