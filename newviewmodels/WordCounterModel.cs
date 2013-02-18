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
            set { this.RaiseAndSetIfChanged(x => x.TextInput, value); }
        }

        int _WordCount=0;
        public int WordCount
        {
            get { return _WordCount; }
            set { this.RaiseAndSetIfChanged(x => x.WordCount, value); }
        }

        public WordCounterModel(IObservable<string> someBackgroundTicker)
        {
            _BackgroundTicker = new ObservableAsPropertyHelper<string>(someBackgroundTicker, _ => raisePropertyChanged("BackgroundTicker"));
            
            this.ObservableForProperty(x => x.TextInput)
                .Throttle(TimeSpan.FromSeconds(0.3))
                .Subscribe(_=>WordCount=TextInput.Split()
                .DefaultIfEmpty()
                .Where(s => s.Trim().Length > 0)
                .Count());
        }
    }
}
