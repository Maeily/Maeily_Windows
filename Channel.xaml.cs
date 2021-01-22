using Maeily_Windows.Controls;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Maeily_Windows
{
    /// <summary>
    /// Channel.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Channel : Page
    {
        public List<ChannelUnit> channelUnits = new List<ChannelUnit>();
        private static Channel instance = null;

        public static Channel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Channel();
                }

                return instance;
            }
        }

        private Channel()
        {
            InitializeComponent();
            Loaded += Channel_Loaded;
        }

        public void Channel_Loaded(object sender, RoutedEventArgs e)
        {
            Main.Instance.ItemsChannel.Items.Clear();

            UGridChannel.Children.Clear();

            ((App)Application.Current).LoadChannel();
            channelUnits = ((App)Application.Current).GetChannelUnitList();

            foreach (ChannelUnit item in channelUnits)
            {
                item.Height = 90;
                UGridChannel.Children.Add(item);
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddChannel addChannel = new AddChannel();

            ((App)Application.Current).mainWindow.Frame.NavigationService.Navigate(addChannel);
        }
    }
}