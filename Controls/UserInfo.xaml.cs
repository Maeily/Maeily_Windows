using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Maeily_Windows.Controls
{
    /// <summary>
    /// UserInfo.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UserInfo : UserControl
    {
        private User userInfo;

        public UserInfo(User user)
        {
            InitializeComponent();
            userInfo = user;
            Loaded += UserInfo_Loaded;
        }

        private void UserInfo_Loaded(object sender, RoutedEventArgs e)
        {
            image.Source = this.userInfo.imageSource;
            TxtUserName.Text = this.userInfo.name;
        }
    }

    public class User
    {
        public ImageSource imageSource { get; set; }
        public string name { get; set; }
    }
}