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
            ((App) Application.Current).LoadChannel(ref UGridChannelList);
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddChannel addChannel = new AddChannel();

            ((App)Application.Current).mainWindow.Frame.NavigationService.Navigate(addChannel);
        }
    }
}