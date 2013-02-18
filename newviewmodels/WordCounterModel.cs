using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;

namespace wpfrxexample.ViewModels
{
    public class WordCounterModel : ReactiveObject
    {
        ObservableAsPropertyHelper<string> _BackgroundTicker;
        public string BackgroundTicker
        {
            get { return _BackgroundTicker.Value; }
        }

        string _TextInput;
        public string TextInput
        {
            get { return _TextInput; }
            set { this.RaiseAndSetIfChanged(ref _TextInput, value); }
        }

        int _WordCount;
        public int WordCount
        {
            get { return _WordCount; }
            set { this.RaiseAndSetIfChanged(ref _WordCount, value); }
        }

        public WordCounterModel(IObservable<string> someBackgroundTicker)
        {
            _BackgroundTicker = new ObservableAsPropertyHelper<string>(someBackgroundTicker, _ => raisePropertyChanged("BackgroundTicker"));
            
            //var __WordCount=new ObservableAsPropertyHelper<int>(
            //    this.ObservableForProperty(x => x.TextInput)
            //        .Select(_ =>   _.Value.Split()
            //                        .DefaultIfEmpty()
            //                        .Where(s => s.Trim().Length > 0)
            //                        .Count()),
            //        _ => raisePropertyChanged("WordCount"));

            this.ObservableForProperty(x => x.TextInput)
                //.Throttle(TimeSpan.FromSeconds(0.3))
                .Subscribe  (_ => WordCount = 
                                    _.Value.Split()
                                    .DefaultIfEmpty()
                                    .Where(s => s.Trim().Length > 0)
                                    .Count()
                            );
        }
    }
}
