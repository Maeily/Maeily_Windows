using Maeily_Windows.Controls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Maeily_Windows
{
    /// <summary>
    /// Channel_Settings.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Channel_Settings : Page
    {
        private List<CalendarContent> contents = new List<CalendarContent>();
        private DateTime dateTime = DateTime.UtcNow;
        private string channelName = string.Empty;

        public Channel_Settings(DateTime dateTime, string channelName)
        {
            InitializeComponent();
            BtnAddContent.Click += new RoutedEventHandler(BtnAddContent_Click);
            Loaded += Channel_Settings_Loaded;
            this.dateTime = dateTime;
            this.channelName = channelName;
        }

        private void Channel_Settings_Loaded(object sender, RoutedEventArgs e)
        {
            contents.Clear();
            ListSchedules.ItemsSource = contents;
            ListSchedules.Items.Refresh();

            StreamReader reader = new StreamReader("Channel/Schedules/" + channelName + ".txt");
            JArray jArray = JArray.Parse(reader.ReadToEnd());

            foreach (JObject item in jArray)
            {
                if (item["start_date"].ToString() == dateTime.ToString("yyyyMMdd"))
                {
                    contents.Add(new CalendarContent(1, item["title"].ToString()));
                }
            }

            ListSchedules.ItemsSource = contents;
            ListSchedules.Items.Refresh();
            reader.Close();
        }

        public void BtnAddContent_Click(object sender, RoutedEventArgs e)
        {
            if (TbContent.Visibility == Visibility.Hidden)
            {
                TbContent.Visibility = Visibility.Visible;
            }
            else
            {
                AddCalendar();
                TbContent.Visibility = Visibility.Hidden;
                TbContent.Text = null;
            }
        }

        private void AddCalendar()
        {
            if (TbContent.Text != "")
            {
                CalendarContent content = new CalendarContent(1, TbContent.Text);

                contents.Add(content);

                FileInfo file = new FileInfo("Channel/Schedules/" + channelName + ".txt");

                if (file.Exists)
                {
                    StreamReader reader = new StreamReader(file.FullName);
                    JArray jArray = JArray.Parse(reader.ReadToEnd());

                    jArray.Add(JObject.FromObject(
                        new
                        {
                            channel_id = channelName,
                            title = TbContent.Text,
                            start_date = dateTime.ToString("yyyyMMdd"),
                            end_date = dateTime.ToString("yyyyMMdd")
                        }));

                    reader.Close();

                    StreamWriter writer = File.CreateText(file.FullName);

                    writer.Write(JsonConvert.SerializeObject(jArray));
                    writer.Close();
                }

                ListSchedules.ItemsSource = contents;

                ListSchedules.Items.Refresh();
            }
            else
            {
                MessageBox.Show("입력 칸을 채워주세요!", "메일리");
            }
        }
    }
}