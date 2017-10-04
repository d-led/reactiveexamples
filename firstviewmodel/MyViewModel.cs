using System;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;

namespace wpfrxexample.ViewModels
{

    public class MyViewModel : INotifyPropertyChanged
    {
        readonly IScheduler scheduler;

        //http://msdn.microsoft.com/en-us/library/ms229614.aspx
        public event PropertyChangedEventHandler PropertyChanged;
        void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        string _CurrentTime;
        public string CurrentTime
        {
            get { return _CurrentTime; }
            private set
            {
                if (value != _CurrentTime)
                {
                    _CurrentTime = value;
                    NotifyPropertyChanged();
                }
            }
        }

        string _TextInput;
        public string TextInput
        {
            get { return _TextInput; }
            set
            {
                if (value != _TextInput)
                {
                    _TextInput = value;
                    NotifyPropertyChanged();
                    UpdateWordCount();
                }
            }
        }

        void UpdateWordCount()
        {
            WordCount = TextInput.Split()
                .DefaultIfEmpty()
                .Where(s => s.Trim().Length > 0)
                .Count();
        }

        int _WordCount;
        public int WordCount
        {
            get { return _WordCount; }
            private set
            {
                if (value != _WordCount)
                {
                    _WordCount = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public MyViewModel(IScheduler sch)
        {
            if (sch != null)
                scheduler = sch;
            else
                scheduler = System.Reactive.Concurrency.Scheduler.Default;
            Observable.Interval(TimeSpan.FromSeconds(1))
                .ObserveOn(scheduler)
                .Subscribe(_ => CurrentTime = DateTime.Now.ToLongTimeString());
        }
    }
}
