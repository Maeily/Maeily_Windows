﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Maeily_Windows.Controls
{
    /// <summary>
    /// CalendarContent.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CalendarContent : UserControl
    {
        private int important = 1;
        private string content = string.Empty;

        public CalendarContent(int important, string content)
        {
            InitializeComponent();
            Loaded += CalendarContent_Loaded;

            this.important = important;
            this.content = content;
        }

        private void CalendarContent_Loaded(object sender, RoutedEventArgs e)
        {
            if (important == 1)
            {
                retangle.Fill = Brushes.Red;
            }
            else if (important == 2)
            {
                retangle.Fill = Brushes.Yellow;
            }
            else
            {
                retangle.Fill = Brushes.Green;
            }

            TxtContent.Text = content;
        }
    }
}