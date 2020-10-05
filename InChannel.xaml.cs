using System;
using System.Collections.Generic;
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
        public InChannel()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(InChannel_Loaded);
            BtnLeft.Click += new RoutedEventHandler(ChangeDate);
            BtnRight.Click += new RoutedEventHandler(ChangeDate);
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
            AddCalendar("dwada");
            RefreshDate();
        }

        private void AddCalendar(string data)
        {
            StackPanel stackPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(10)
            };
            Rectangle rectangle = new Rectangle();
            rectangle.Width = 10;
            rectangle.Height = 10;
            rectangle.Margin = new Thickness(60, 0, 0, 0);
            rectangle.Fill = Brushes.Black;
            TextBlock textBlock = new TextBlock() { 
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(10, 0, 0, 0),
                Text = data
            };
            stackPanel.Children.Add(rectangle);
            stackPanel.Children.Add(textBlock);
            Calendars.Add(stackPanel);
            CalendarList.ItemsSource = Calendars;
            CalendarList.Items.Refresh();
        } 
    }
}
