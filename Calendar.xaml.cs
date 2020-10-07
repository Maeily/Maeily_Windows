﻿using System;
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
    /// Calendar.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Calendar : Page
    {
        private DateTime dateTime = DateTime.UtcNow;

        public Calendar()
        {
            InitializeComponent();

            Loaded += new RoutedEventHandler(Calendar_Loaded);
        }

        private void Calendar_Loaded(object sender, RoutedEventArgs args)
        {
            int i;

            LbTitleDate.Content = dateTime.ToString("yyyy년 MM월");

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
            }
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