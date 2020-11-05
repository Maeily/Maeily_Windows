﻿using Maeily_Windows.Controls;
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
        private List<CalendarContent> contents = new List<CalendarContent>();
        private static Calendar instance = null;
        private List<List<CalendarContent>> scuedules = new List<List<CalendarContent>>();

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
            scuedules.Clear();
            scuedules = ((App)Application.Current).scheduleList;
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
                UGridCalendar.Children.Add(button);

                if (DateTime.UtcNow.Day.ToString().Equals(i.ToString()))
                {
                    BrushConverter brushConverter = new BrushConverter();
                    button.Foreground = (Brush)brushConverter.ConvertFrom("#B7DE4B");
                }
            }
        }

        private void AddContent(int important, DateTime time, string contentStr)
        {
            CalendarContent content = new CalendarContent(1, time, contentStr);

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