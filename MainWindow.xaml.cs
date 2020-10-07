using System;
using System.Windows;
using System.Windows.Navigation;

namespace Maeily_Windows
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Main(object sender, RoutedEventArgs e)
        {
            Frame.Source = new Uri("Main.xaml", UriKind.Relative);
        }

        private void Channel(object sender, RoutedEventArgs e)
        {
            Frame.Source = new Uri("Channel.xaml", UriKind.Relative);
        }

        private void Calender(object sender, RoutedEventArgs e)
        {
            Frame.Source = new Uri("Calendar.xaml", UriKind.Relative);
        }

        private void Setting(object sender, RoutedEventArgs e)
        {
            Frame.Source = new Uri("Settings.xaml", UriKind.Relative); // show hide
        }
    }
}