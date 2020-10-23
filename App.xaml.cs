using Maeily_Windows.Controls;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace Maeily_Windows
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        public MainWindow mainWindow = new MainWindow();
        private SignIn signIn = new SignIn();
        public string userID = string.Empty;

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

        public void LoadChannel(ref UniformGrid UGrid)
        {
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
                            ChannelUnit channelUnit = new ChannelUnit(item.Name.Replace(".txt", ""));
                            channelUnit.Width = 130;
                            channelUnit.Height = 90;

                            isJoined = false;
                            UGrid.Children.Add(channelUnit);
                        }
                    }
                }
            }
        }
    }
}