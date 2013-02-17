using System;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;

namespace wpfrxexample.ViewModels
{

    public class MyViewModel : INotifyPropertyChanged
    {
        //http://msdn.microsoft.com/en-us/library/ms229614.aspx
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        string _CurrentTime;
        public string CurrentTime
        {
            get { return _CurrentTime; }
            set
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

        private void UpdateWordCount()
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
            set
            {
                if (value != _WordCount)
                {
                    _WordCount = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public MyViewModel()
        {
            Observable.Interval(TimeSpan.FromSeconds(1))
                .Subscribe(_ => CurrentTime = DateTime.Now.ToLongTimeString());
        }
    }
}
