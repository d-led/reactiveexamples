﻿using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Controls;

namespace wpfrxexample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IDisposable subscription;

        public MainWindow()
        {
            InitializeComponent();
        }

        void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            ViewModels.MyViewModel VM = new ViewModels.MyViewModel(null);
            DataContext = VM;
            var textChanged = Observable.FromEventPattern<TextChangedEventHandler, TextChangedEventArgs>(
                handler => handler.Invoke,
                h => textBox3.TextChanged += h,
                h => textBox3.TextChanged -= h);
            subscription = textChanged.Subscribe(_ => VM.TextInput = textBox3.Text);
        }
    }
}
