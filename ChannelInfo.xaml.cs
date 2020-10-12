using Maeily_Windows.Controls;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Maeily_Windows
{
    /// <summary>
    /// ChannelInfo.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ChannelInfo : Page
    {
        private List<UserInfo> Users = new List<UserInfo>();

        public ChannelInfo()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(ChannelInfo_Loaded);
        }

        private void ChannelInfo_Loaded(object sender, RoutedEventArgs args)
        {
            AddUserProfile(new BitmapImage(new Uri("Resources/AddBtn.png", UriKind.Relative)), "1117 임경준");
        }

        private void AddUserProfile(ImageSource imgSrc, string userInfo)
        {
            UserInfo user = new UserInfo(new User { imageSource = new BitmapImage(new Uri(@"/Resources/AddBtn.png", UriKind.Relative)), name = "테스트" });

            Users.Add(user);
            Userlist.ItemsSource = Users;
            Userlist.Items.Refresh();
        }
    }
}