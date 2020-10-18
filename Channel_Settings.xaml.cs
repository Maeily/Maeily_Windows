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
            this.dateTime = dateTime;
            this.channelName = channelName;
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
                        new { date = dateTime.ToString("MMdd"), content = TbContent.Text }));

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