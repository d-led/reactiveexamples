using System;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Forms;

// Rx and WinForms Example by Dmitry Ledentsov, 16.02.2013
namespace winformsexample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Observable.Interval(TimeSpan.FromSeconds(1))
                .ObserveOn(this)
                .Subscribe(x => textBox1.Text = DateTime.Now.ToLongTimeString());

            var textChanged = Observable.FromEventPattern
                <EventHandler, EventArgs>(
                handler => handler.Invoke,
                h => textBox3.TextChanged+= h,
                h => textBox3.TextChanged-= h);

            textChanged
                .ObserveOn(this)
                .Subscribe(x => textBox2.Text =
                    textBox3.Text
                    .Split()
                    .DefaultIfEmpty()
                    .Where(s=>s.Trim().Length>0)
                    .Count()
                    .ToString());
        }
    }
}
