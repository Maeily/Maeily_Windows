using Maeily_Windows.Controls;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Maeily_Windows
{
    /// <summary>
    /// ChannelInfo.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ChannelInfo : Page
    {
        private List<UserInfo> Users = new List<UserInfo>();
        private string channelName = string.Empty;

        public ChannelInfo(string channelName)
        {
            InitializeComponent();
            Loaded += ChannelInfo_Loaded;

            this.channelName = channelName;
        }

        private void ChannelInfo_Loaded(object sender, RoutedEventArgs args)
        {
            AddUserProfile();
        }

        private void AddUserProfile()
        {
            JArray jArray = new JArray();
            //            UserInfo user = new UserInfo(new User { imageSource = new BitmapImage(new Uri(@"/Resources/AddBtn.png", UriKind.Relative)), name = "테스트" });
            //
            //            Users.Add(user);
            //            Userlist.ItemsSource = Users;
            //            Userlist.Items.Refresh();
            StreamReader reader = new StreamReader("Channel/UserList/" + channelName + ".txt");

            jArray = JArray.Parse(reader.ReadToEnd());

            MessageBox.Show(jArray.ToString());
            reader.Close();
        }
    }
}