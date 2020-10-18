using Maeily_Windows.Controls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Maeily_Windows
{
    /// <summary>
    /// InChannel.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class InChannel : Page
    {
        List<StackPanel> Calendars = new List<StackPanel>();
        DateTime dateTime = DateTime.UtcNow;
        private string channelName = string.Empty;
        public InChannel(string channelName)
        {
            InitializeComponent();
            this.channelName = channelName;
            Loaded += new RoutedEventHandler(InChannel_Loaded);
            BtnLeft.Click += new RoutedEventHandler(ChangeDate);
            BtnRight.Click += new RoutedEventHandler(ChangeDate);
            MessageBox.Show(this.channelName);
        }

        private void ChangeDate(object sender, RoutedEventArgs args)
        {
            if ((sender as Button).Tag.Equals("Left"))
            {
                dateTime = dateTime.AddDays(-1);
            } else
            {
                dateTime = dateTime.AddDays(1);
            }
            RefreshDate();
        }

        private void RefreshDate()
        {
            LbLeftDate.Content = dateTime.AddDays(-1).Day.ToString() + "일";
            LbMiddleDate.Content = dateTime.Day.ToString() + "일";
            LbRightDate.Content = dateTime.AddDays(1).Day.ToString() + "일";
        }

        private void InChannel_Loaded(object sender, RoutedEventArgs args)
        {
            AddCalendar();
            RefreshDate();
        }

        private void AddCalendar()
        {
            MessageBox.Show("add" + Environment.NewLine + channelName);
            StreamReader reader = new StreamReader("Channel/Schedules/" + channelName + ".txt");
            var jObject = JsonConvert.DeserializeObject(reader.ReadToEnd());

            MessageBox.Show(jObject.ToString());
            CalendarList.ItemsSource = Calendars;
            CalendarList.Items.Refresh();
            reader.Close();
        }

        private void BtnSettings_Click(object sender, RoutedEventArgs e)
        {
            Channel_Settings channel_Settings = new Channel_Settings(dateTime, channelName);

            ((MainWindow) System.Windows.Application.Current.MainWindow).
                Frame.NavigationService.Navigate(channel_Settings);
        }
    }
}
