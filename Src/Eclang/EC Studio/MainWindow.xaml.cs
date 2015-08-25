using System.Windows;

namespace EC_Studio
{
    using System;

    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuFileExit_OnClick(object sender, RoutedEventArgs e)
        {
           Environment.Exit(0);
        }
    }
}
