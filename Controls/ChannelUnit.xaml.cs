using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Maeily_Windows.Controls
{
    public partial class ChannelUnit : UserControl
    {
        private string channelName = string.Empty;
        public ChannelUnit(String channelName)
        {
            InitializeComponent();
            Loaded += ChannelUnit_Loaded;
            BtnChannelUnit.Click += BtnChannelUnit_Click;

            this.channelName = channelName;
        }

        private void BtnChannelUnit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(TxtChannelName.Text);
        }

        private void ChannelUnit_Loaded(object sender, RoutedEventArgs e)
        {
            TxtChannelName.Text = channelName;
            FileInfo fileInfo = new FileInfo(@"Channel/Resources/" + channelName + ".jpg");

            ImgChannelImage.Source = new BitmapImage(new Uri(fileInfo.FullName, UriKind.Absolute));
        }
    }
}
