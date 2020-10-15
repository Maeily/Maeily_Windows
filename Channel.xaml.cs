using Maeily_Windows.Controls;
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
        private string[] fileNames = { "" };

        public Channel()
        {
            InitializeComponent();
            Loaded += Channel_Loaded;
        }

        private void Channel_Loaded(object sender, RoutedEventArgs e)
        {
            DirectoryInfo directory = new DirectoryInfo("Channel");

            if (directory.Exists)
            {
                foreach (var item in directory.GetFiles())
                {
                    ChannelUnit channelUnit = new ChannelUnit(item.Name.Replace(".txt", ""));

                    UGridChannelList.Children.Add(channelUnit);
                }
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}