using System.Collections.Generic;
using Maeily_Windows.Controls;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Documents;

namespace Maeily_Windows
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        private SignIn signIn = new SignIn();
        public List<List<CalendarContent>> scheduleList = new List<List<CalendarContent>>();
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
        }

        public ObservableCollection<ChannelUnit> LoadChannel(string sender)
        {
            ObservableCollection<ChannelUnit> channelUnits = new ObservableCollection<ChannelUnit>();
            DirectoryInfo directory = new DirectoryInfo("Channel");
            FileInfo[] fileInfos = directory.GetFiles("*.txt");
            StreamReader streamReader = null;
            JArray jArray = new JArray();
            bool isJoined = false;

            if (directory.Exists)
            {
                if (fileInfos.Length != 0)
                {
                    foreach (var item in fileInfos)
                    {
                        streamReader = new StreamReader("Channel/UserList/" + item.Name);
                        jArray = JArray.Parse(streamReader.ReadToEnd());

                        foreach (JObject data in jArray)
                        {
                            if (data["id"].ToString().Equals(((App)Application.Current).userID))
                            {
                                isJoined = true;
                                break;
                            }
                        }

                        if (isJoined)
                        {
                            if (sender.Equals("Main"))
                            {
                                if (channelUnits.Count >= 4)
                                {
                                    return channelUnits;
                                }
                            }

                            ChannelUnit channelUnit = new ChannelUnit(item.Name.Replace(".txt", ""));
                            channelUnit.Width = 130;
                            channelUnit.Height = 90;

                            isJoined = false;
                            channelUnits.Add(channelUnit);
                        }
                    }
                }
            }

            return channelUnits;
        }
    }
}