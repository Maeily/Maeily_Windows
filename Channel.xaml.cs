using Maeily_Windows.Controls;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Maeily_Windows
{
    /// <summary>
    /// Channel.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Channel : Page
    {
        public Channel()
        {
            InitializeComponent();
            Loaded += Channel_Loaded;
        }

        private void Channel_Loaded(object sender, RoutedEventArgs e)
        {
            DirectoryInfo directory = new DirectoryInfo("Channel");
            FileInfo[] fileInfos = directory.GetFiles("*.txt");
            StreamReader streamReader;
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

                            isJoined = false;
                            UGridChannelList.Children.Add(channelUnit);
                        }
                    }
                }
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddChannel addChannel = new AddChannel();

            ((App)Application.Current).mainWindow.Frame.NavigationService.Navigate(addChannel);
        }
    }
}