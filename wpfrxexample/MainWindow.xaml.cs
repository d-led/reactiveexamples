using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.CompilerServices;
using System.Reactive.Linq;

namespace wpfrxexample
{

    public class MyViewModel: INotifyPropertyChanged 
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

        public MyViewModel() {
            Observable.Interval(TimeSpan.FromSeconds(1))
             .Subscribe(_ => CurrentTime = DateTime.Now.ToLongTimeString());
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            MyViewModel VM = new MyViewModel();
            DataContext = VM;
            var textChanged = Observable.FromEventPattern<TextChangedEventHandler, TextChangedEventArgs>(
                handler => handler.Invoke,
                h => textBox3.TextChanged += h,
                h => textBox3.TextChanged -= h);
            textChanged.Subscribe(_ => VM.TextInput = textBox3.Text);
        }
    }
}
