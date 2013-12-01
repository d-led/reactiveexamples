using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winformsvm
{
    public partial class Form1 : Form
    {
        IScheduler scheduler;
        public Form1()
        {
            scheduler = new System.Reactive.Concurrency.ControlScheduler(this);
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            wpfrxexample.ViewModels.MyViewModel VM = new wpfrxexample.ViewModels.MyViewModel(scheduler);

            textBox1.DataBindings.Add("Text", VM, "CurrentTime");
            textBox2.DataBindings.Add("Text", VM, "WordCount");

            var textChanged = Observable.FromEventPattern
                <EventHandler, EventArgs>(
                handler => handler.Invoke,
                h => textBox3.TextChanged += h,
                h => textBox3.TextChanged -= h);

            textChanged
                .Throttle(TimeSpan.FromSeconds(0.3))
                .ObserveOn(scheduler)
                .SubscribeOn(this)
                .Subscribe(_ => VM.TextInput = textBox3.Text);
        }
    }
}
