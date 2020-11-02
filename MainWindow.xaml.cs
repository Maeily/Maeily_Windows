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
            Loaded += MainWindow_Loaded;
            LoadMeal loadMeal = new LoadMeal("https://open.neis.go.kr/hub/mealServiceDietInfo?ATPT_OFCDC_SC_CODE=D10&SD_SCHUL_CODE=7240393&MLSV_FROM_YMD=" + dateTime.ToString("yyyyMMdd") + "&MLSV_TO_YMD=" + dateTime.ToString("yyyyMMdd") + "&Type=json");
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ChangePage(Main.Instance);
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

        private void Main_Click(object sender, RoutedEventArgs e)
        {
            Frame.NavigationService.Navigate(Main.Instance);
        }

        private void Channel_Click(object sender, RoutedEventArgs e)
        {
            ChangePage(Channel.Instance);
        }

        private void Calender_Click(object sender, RoutedEventArgs e)
        {
            ChangePage(Calendar.Instance);
        }

        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            ChangePage(Settings.Instance);
        }

        public void ChangePage(object page)
        {
            Frame.NavigationService.Navigate(page);
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