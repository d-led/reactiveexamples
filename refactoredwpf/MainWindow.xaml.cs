using System.Windows;

namespace refactoredwpf
{
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
            wpfrxexample.ViewModels.BackgroundTicker Ticker=new wpfrxexample.ViewModels.BackgroundTicker();
            wpfrxexample.ViewModels.WordCounterModel VM = new wpfrxexample.ViewModels.WordCounterModel(Ticker.Ticker);
            DataContext = VM;
        }
    }
}
