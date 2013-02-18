using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfrxexample.ViewModels
{
    public class BackgroundTicker
    {
        public IObservable<string> Ticker
        {
            get
            {
                return Observable
                    .Interval(TimeSpan.FromSeconds(1))
                    .Select(_ => DateTime.Now.ToLongTimeString());
            }
        }
    }
}
