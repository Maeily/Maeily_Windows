using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

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

            if (fileInfo.Exists)
            {
                ImgChannelImage.Source = new BitmapImage(new Uri(fileInfo.FullName, UriKind.Absolute));
            }
        }
    }
}