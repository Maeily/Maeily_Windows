using Maeily_Windows.Controls;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Maeily_Windows
{
    /// <summary>
    /// Calendar.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Calendar : Page
    {
        private DateTime dateTime = DateTime.UtcNow;
        private List<CalendarContent> contents = new List<CalendarContent>();   //표시되는 일정
        private static Calendar instance = null;
        private Dictionary<string, List<CalendarContent>> schedules = new Dictionary<string, List<CalendarContent>>();
        private Dictionary<string, List<CalendarContent>>.KeyCollection keys = null;

        public static Calendar Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Calendar();
                }

                return instance;
            }
        }

        private Calendar()
        {
            InitializeComponent();

            CalendarLoad();
            Loaded += Calendar_Loaded;
        }

        private void Calendar_Loaded(object sender, RoutedEventArgs e)
        {
            schedules.Clear();
            schedules = ((App)Application.Current).scheduleList;
            keys = schedules.Keys;
            LoadSchedules();
        }

        private void LoadSchedules()
        {
            contents.Clear();
            ListContents.ItemsSource = null;
            ListContents.Items.Clear();
            ListContents.Items.Refresh();

            foreach (var item in keys)
            {
                foreach (CalendarContent data in schedules[item])
                {
                    if (data.dateTime.ToString("yyyy MM dd") ==
                        dateTime.ToString("yyyy MM dd"))
                    {
                        AddContent(data);
                    }
                }
            }
        }

        private void CalendarLoad()
        {
            int i;

            LbTitleDate.Content = dateTime.ToString("yyyy년 MM월 dd일");

            UGridCalendar.FirstColumn = CheckDateColumn();

            for (i = 1; i <= DateTime.DaysInMonth(dateTime.Year, dateTime.Month); i++)
            {
                Button button = new Button()
                {
                    Width = 25,
                    Height = 25,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Tag = i.ToString(),
                    Background = Brushes.Transparent,
                    BorderBrush = Brushes.Transparent
                };
                TextBlock textBlock = new TextBlock()
                {
                    Text = i.ToString(),
                };
                textBlock.FontWeight = FontWeights.Bold;
                button.Content = textBlock;

                button.Click += new RoutedEventHandler((object sender, RoutedEventArgs ev) =>
                {
                    Calendar.Instance.dateTime =
                        Instance.dateTime.AddDays(int.Parse(textBlock.Text) - dateTime.Day);
                    instance.LoadSchedules();

                    MessageBox.Show(dateTime.Day.ToString());
                });
                UGridCalendar.Children.Add(button);

                if (DateTime.UtcNow.Day.ToString().Equals(i.ToString()))
                {
                    BrushConverter brushConverter = new BrushConverter();
                    button.Foreground = (Brush)brushConverter.ConvertFrom("#B7DE4B");
                }
            }
        }

        private void AddContent(CalendarContent content)
        {
            contents.Add(content);

            ListContents.ItemsSource = contents;
            ListContents.Items.Refresh();
        }

        private int CheckDateColumn()
        {
            int first = 0;
            switch (new DateTime(dateTime.Year, dateTime.Month, 1).DayOfWeek.ToString())
            {
                case "Sunday":
                    first = 0;
                    break;

                case "Monday":
                    first = 1;
                    break;

                case "Tuesday":
                    first = 2;
                    break;

                case "Wednesday":
                    first = 3;
                    break;

                case "Thursday":
                    first = 4;
                    break;

                case "Friday":
                    first = 5;
                    break;

                case "Saturday":
                    first = 6;
                    break;
            }
            return first;
        }
    }
}