using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reactive.Concurrency;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace winformsnoevents
{
    public partial class Form1 : Form, IViewFor<MyViewModel>
    {
        public Form1()
        {
            InitializeComponent();

            VM = new MyViewModel(WindowsFormsSynchronizationContext.Current,this.WhenAnyValue(x => x.inputBox.Text));
            this.Bind(VM, x => x.BackgroundTicker, x => x.tickerBox.Text);
            this.Bind(VM, x => x.WordCount, x => x.wordCountBox.Text);
        }

        public MyViewModel VM { get; set; }

        Control BackgroundTicker
        {
            get { return this.tickerBox; }
        }

        object IViewFor.ViewModel
        {
            get { return VM; }
            set { VM = (MyViewModel)value; }
        }

        MyViewModel IViewFor<MyViewModel>.ViewModel
        {
            get { return VM; }
            set { VM = value; }
        }
    }
}
