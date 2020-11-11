using Maeily_Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Maeily_Windows
{
    /// <summary>
    /// Channel.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Channel : Page
    {
        public ObservableCollection<ChannelUnit> channelUnits = new ObservableCollection<ChannelUnit>();
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

        private void Channel_Loaded(object sender, RoutedEventArgs e)
        {
            UGridChannel.Children.Clear();

//            channelUnits = ((App)Application.Current).LoadChannel("Channel");

            foreach (ChannelUnit item in channelUnits)
            {
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