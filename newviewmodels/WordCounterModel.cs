using ReactiveUI;
using System;
using System.Linq;
using System.Reactive.Linq;

namespace wpfrxexample.ViewModels
{
    public class WordCounterModel : ReactiveObject
    {
        readonly ObservableAsPropertyHelper<string> _BackgroundTicker;
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

        readonly ObservableAsPropertyHelper<int> _WordCount;
        public int WordCount
        {
            get { return _WordCount.Value; }
        }

        public WordCounterModel(IObservable<string> someBackgroundTicker)
        {
            someBackgroundTicker
                .ToProperty(this, ticker => ticker.BackgroundTicker, out _BackgroundTicker);

            this.WhenAnyValue(x => x.TextInput)
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x
                    .Split()
                    .Count(word => !string.IsNullOrWhiteSpace(word)))
                .ToProperty(this, vm => vm.WordCount, out _WordCount);
        }
    }
}
