using Maeily_Windows.Controls;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace Maeily_Windows
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        private SignIn signIn = new SignIn();
        public Dictionary<string, List<CalendarContent>> scheduleList = new Dictionary<string, List<CalendarContent>>();
        public List<string> channelsList = new List<string>();
        public List<ChannelUnit> channelUnitsList = new List<ChannelUnit>();
        public string userID = string.Empty;
        public MainWindow mainWindow = new MainWindow();

        public void LogIn(string id)
        {
            userID = id;
            signIn.Hide();
            mainWindow.Show();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            signIn.Show();
            LoadChannel();
        }

        public void LoadChannel()
        {
            List<ChannelUnit> channelUnits = new List<ChannelUnit>();
            DirectoryInfo directory = new DirectoryInfo("Channel");
            FileInfo[] fileInfos = directory.GetFiles("*.txt");
            StreamReader streamReader = null;
            JArray jArray = new JArray();
            bool isJoined = false;

            scheduleList.Clear();

            if (directory.Exists)
            {
                foreach (FileInfo item in fileInfos)
                {
                    string channelName = item.Name.Replace(".txt", "");
                    List<CalendarContent> contents = new List<CalendarContent>();
                    ChannelUnit channelUnit = new ChannelUnit(channelName);

                    channelsList.Add(channelName);
                    channelUnitsList.Add(channelUnit);

                    streamReader = new StreamReader("Channel/Schedules/" + item.Name);
                    jArray = JArray.Parse(streamReader.ReadToEnd());

                    foreach (JObject data in jArray)
                    {
                        contents.Clear();

                        CalendarContent calendarContent = new CalendarContent(
                    int.Parse(data["important"].ToString()),
                            DateTime.Parse(data["start_date"].ToString()),
                        data["title"].ToString()
                        );
                        contents.Add(calendarContent);
                    }

                    scheduleList.Add(channelName, contents);
                }
            }
        }
    }
}