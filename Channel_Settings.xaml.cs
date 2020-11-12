using Maeily_Windows.Controls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Data;

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
        private int important;
        private List<CheckBox> checkBoxes = new List<CheckBox>();

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
                if (item["start_date"].ToString() == dateTime.ToString("yyyy MM dd"))
                {
                    contents.Add(new CalendarContent(int.Parse(item["important"].ToString()),
                        DateTime.Parse(item["start_date"].ToString()),
                        item["title"].ToString()));
                }
            }

            ListSchedules.ItemsSource = contents;
            ListSchedules.Items.Refresh();
            reader.Close();

            WorkMenuVisibility();
        }

        public void BtnAddContent_Click(object sender, RoutedEventArgs e)
        {
            if (InGroup.Visibility == Visibility.Hidden)
            {
                InGroup.Visibility = Visibility.Visible;
            }
            else
            {
                AddCalendar();
                InGroup.Visibility = Visibility.Hidden;
                TbContent.Text = null;
                radio1.IsChecked = false;
                radio2.IsChecked = false;
                radio3.IsChecked = false;
            }
        }

        private void AddCalendar()
        {
            if (TbContent.Text != "")
            {
                if (radio1.IsChecked == true)
                {
                    important = 1;
                }
                else if (radio2.IsChecked == true)
                {
                    important = 2;
                }
                else if (radio3.IsChecked == true)
                {
                    important = 3;
                }
                else
                {
                    MessageBox.Show("입력 칸을 채워주세요!", "메일리");
                    return;
                }
                CalendarContent content = new CalendarContent(important, DateTime.UtcNow, TbContent.Text);

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
                            start_date = dateTime.ToString("yyyy MM dd"),
                            end_date = dateTime.ToString("yyyy MM dd"),
                            important = important
                        }));

                    reader.Close();

                    StreamWriter writer = File.CreateText(file.FullName);

                    writer.Write(JsonConvert.SerializeObject(jArray));
                    writer.Close();
                }

                ListSchedules.ItemsSource = contents;

                ListSchedules.Items.Refresh();
                DeleteButton.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("입력 칸을 채워주세요!", "메일리");
            }
        }

        private void NameChangeButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            

            if (string.Compare(button.Content.ToString(), "이름변경") == 0)
            {
                
                button.Content = "완료";
            }
            else
            {
                

                button.Content = "이름변경";
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (string.Compare(button.Content.ToString(), "삭제") == 0)
            {
                for (int i = 0; i < ListSchedules.Items.Count; i++)
                {
                    checkBoxes.Add(new CheckBox
                    {
                        Width = 20,
                        Height = 20,
                        Margin = new Thickness(3)
                    });
                }
                CheckBoxList.ItemsSource = checkBoxes;
                CheckBoxList.Items.Refresh();
                button.Content = "완료";
            }
            else
            {
                StreamReader reader = new StreamReader("Channel/Schedules/" + channelName + ".txt");
                JArray jArray = JArray.Parse(reader.ReadToEnd());
                reader.Close();

                for (int i=0; i< ListSchedules.Items.Count; i++)
                {
                    if (checkBoxes[i].IsChecked == true)
                    {
                        contents.Remove(contents[i]);
                        jArray.Remove(jArray[i]);
                    }
                }

                ListSchedules.ItemsSource = contents;
                ListSchedules.Items.Refresh();

                StreamWriter writer = new StreamWriter("Channel/Schedules/" + channelName + ".txt", false);
                writer.Write(JsonConvert.SerializeObject(jArray));
                writer.Close();

                CheckBoxList.ItemsSource = null;
                CheckBoxList.Items.Clear();
                CheckBoxList.Items.Refresh();

                button.Content = "삭제";

                WorkMenuVisibility();
            }
        }

        private void WorkMenuVisibility()
        {
            if(contents.Count == 0)
            {
                WorkMenu.Visibility = Visibility.Hidden;
            }
            else
            {
                WorkMenu.Visibility = Visibility.Visible;
            }
        }
    }
}