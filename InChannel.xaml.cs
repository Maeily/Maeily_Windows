﻿using Maeily_Windows.Controls;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Maeily_Windows
{
    /// <summary>
    /// InChannel.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class InChannel : Page
    {
        private List<CalendarContent> calendars = new List<CalendarContent>();
        private DateTime dateTime = DateTime.UtcNow;
        private string channelName = string.Empty;

        public InChannel(string channelName)
        {
            InitializeComponent();
            this.channelName = channelName;
            Loaded += new RoutedEventHandler(InChannel_Loaded);
            BtnLeft.Click += new RoutedEventHandler(ChangeDate);
            BtnRight.Click += new RoutedEventHandler(ChangeDate);
            BtnShowChInfo.Click += BtnShowChInfo_Click;
        }

        private void BtnShowChInfo_Click(object sender, RoutedEventArgs e)
        {
            ChannelInfo channelInfo = new ChannelInfo(channelName);

            ((App)Application.Current).mainWindow.Frame.NavigationService.Navigate(channelInfo);
        }

        private void ChangeDate(object sender, RoutedEventArgs args)
        {
            if ((sender as Button).Tag.Equals("Left"))
            {
                dateTime = dateTime.AddDays(-1);
            }
            else
            {
                dateTime = dateTime.AddDays(1);
            }
            RefreshDate();
            AddCalendar();
        }

        private void RefreshDate()
        {
            LbLeftDate.Content = dateTime.AddDays(-1).Day.ToString() + "일";
            LbMiddleDate.Content = dateTime.Day.ToString() + "일";
            LbRightDate.Content = dateTime.AddDays(1).Day.ToString() + "일";
            LbMonth.Content = dateTime.ToString("yyyy년MM월");
        }

        private void InChannel_Loaded(object sender, RoutedEventArgs args)
        {
            AddCalendar();
            RefreshDate();
        }

        private void AddCalendar()
        {
            calendars.Clear();
            CalendarList.ItemsSource = calendars;
            CalendarList.Items.Refresh();

            StreamReader reader = new StreamReader("Channel/Schedules/" + channelName + ".txt");
            JArray jArray = JArray.Parse(reader.ReadToEnd());

            foreach (JObject item in jArray)
            {
                if (item["start_date"].ToString() == dateTime.ToString("yyyyMMdd"))
                {
                    calendars.Add(new CalendarContent(int.Parse(item["important"].ToString()), item["title"].ToString()));
                }
            }

            CalendarList.ItemsSource = calendars;
            CalendarList.Items.Refresh();
            reader.Close();
        }

        private void BtnSettings_Click(object sender, RoutedEventArgs e)
        {
            Channel_Settings channel_Settings = new Channel_Settings(dateTime, channelName);

            ((App)Application.Current).mainWindow.Frame.NavigationService.Navigate(channel_Settings);
        }
    }
}