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
        Widget widget = new Widget();
        public MainWindow()
        {
            InitializeComponent();
            StateChanged += MainWindow_StateChanged;
        }

        private void MainWindow_StateChanged(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
            {
                widget.Show();
            } else if (WindowState == WindowState.Normal)
            {
                widget.Hide();
            }
        }

        private void Main(object sender, RoutedEventArgs e)
        {
            ChangePage("Main.xaml");
        }

        private void Channel(object sender, RoutedEventArgs e)
        {
            ChangePage("Channel.xaml");
        }

        private void Calender(object sender, RoutedEventArgs e)
        {
            ChangePage("Calendar.xaml");
        }

        private void Setting(object sender, RoutedEventArgs e)
        {
            ChangePage("Settings.xaml");
        }

        public void ChangePage(string target) {
            Frame.Source = new Uri(target, UriKind.Relative); 
        }
    }
}