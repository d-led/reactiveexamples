using ReactiveUI;
using System;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading;

namespace winformsnoevents
{
    public class MyViewModel : ReactiveObject
    {
        private readonly ObservableAsPropertyHelper<string> backgroundTicker;
        public string BackgroundTicker
        {
            get
            {
                return backgroundTicker.Value;
            }
            set {/* read-only properties not implemented yet?*/}
        }

        private readonly ObservableAsPropertyHelper<int> wordCount;
        public int WordCount
        {
            get
            {
                return wordCount.Value;
            }
            set { }
        }

        public MyViewModel(IScheduler scheduler,IObservable<string> input)
        {
            Observable.Interval(TimeSpan.FromSeconds(1))
               .ObserveOn(scheduler)
               .Select(_ => DateTime.Now.ToLongTimeString())
               .ToProperty(this, x => x.BackgroundTicker,out backgroundTicker);

            input
                .Where(x => x != null)
                .Select(s => s.Split().Where(x => x.Trim().Length > 0).Count())
                .Throttle(TimeSpan.FromSeconds(0.3))
                .ObserveOn(scheduler)
                .ToProperty(this, x => x.WordCount, out wordCount);
        }
    }
}
