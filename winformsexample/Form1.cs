using System;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Forms;

namespace winformsexample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void Form1_Load(object sender, EventArgs e)
        {
            Ticker();
            WordCount();
        }

        void Ticker()
        {
            Observable.Interval(TimeSpan.FromSeconds(1))
                .ObserveOn(this)
                .Subscribe(x => textBox1.Text = DateTime.Now.ToLongTimeString());
        }

        void WordCount()
        {
            var textChanged = Observable.FromEventPattern
                <EventHandler, EventArgs>(
                handler => handler.Invoke,
                h => textBox3.TextChanged += h,
                h => textBox3.TextChanged -= h);

            textChanged
                .ObserveOn(this)
                .Subscribe(x => textBox2.Text =
                    textBox3.Text
                    .Split()
                    .DefaultIfEmpty()
                    .Count(word => !string.IsNullOrWhiteSpace(word))
                    .ToString());
        }
    }
}
