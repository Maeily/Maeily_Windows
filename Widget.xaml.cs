using Maeily_Windows.Controls;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Maeily_Windows
{
    /// <summary>
    /// Widget.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Widget : Window
    {
        private Dictionary<string, List<CalendarContent>> schedules = new Dictionary<string, List<CalendarContent>>();
        private Dictionary<string, List<CalendarContent>>.KeyCollection keys = null;

        public Widget()
        {
            InitializeComponent();
            Loaded += WidgetLoaded;
        }

        private void WidgetLoaded(object sender, RoutedEventArgs e)
        {
            InitWorkerW();
            InitOnDisplaySettingChanged();
            ShowOnWorkerW();
            FillDisplay();

            schedules.Clear();
            StackPSchedules.Children.Clear();

            schedules = ((App)Application.Current).scheduleList;
            keys = schedules.Keys;

            TxBTodayDate.Text = DateTime.UtcNow.ToString("MM월 dd일 dddd");

            foreach (var item in keys)
            {
                foreach (CalendarContent data in schedules[item])
                {
                    if (data.dateTime.ToString("yyyy MM dd") ==
                        DateTime.UtcNow.ToString("yyyy MM dd"))
                    {
                        TextBlock textBlock = new TextBlock()
                        {
                            Foreground = Brushes.White,
                            Background = Brushes.Transparent,
                            Text = data.content,
                            FontSize = 15
                        };

                        data.TxtContent.Foreground = Brushes.White;
                        data.TxtContent.FontSize = 15;
                        data.TxtContent.Background = Brushes.Transparent;
                        StackPSchedules.Children.Add(data);
                    }
                }
            }
        }
    }
}