using System;
using System.Windows;

namespace Maeily_Windows
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private DateTime dateTime;
        private string userId = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
            dateTime = DateTime.UtcNow;
            StateChanged += MainWindowStateChanged;
            LoadMeal loadMeal = new LoadMeal("https://open.neis.go.kr/hub/mealServiceDietInfo?ATPT_OFCDC_SC_CODE=D10&SD_SCHUL_CODE=7240393&MLSV_FROM_YMD=" + dateTime.ToString("yyyyMMdd") + "&MLSV_TO_YMD=" + dateTime.ToString("yyyyMMdd") + "&Type=json");
        }

        private void MainWindowStateChanged(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
            {
                CreateWidget.widget.Show();
            }
            else if (WindowState == WindowState.Normal)
            {
                CreateWidget.widget.Hide();
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

        public void ChangePage(string target)
        {
            Frame.Source = new Uri(target, UriKind.Relative);
        }

        public void LoadUser(string id)
        {
            userId = id;
        }
    }

    public static class CreateWidget
    {
        public static Widget widget = new Widget();
    }
}