using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Brush = System.Windows.Media.Brush;
using Brushes = System.Windows.Media.Brushes;

namespace Maeily_Windows.Controls
{
    public partial class ChannelUnit : UserControl
    {
        private string channelName = string.Empty;
        private JObject JObject;

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
                JObject = JObject.Parse(System.IO.File.ReadAllText(@"Channel/" + channelName + ".txt"));
                var converter = new System.Windows.Media.BrushConverter();
                BtnChannelUnit.Background = CheckColor(JObject["color"].ToString());
            }
        }

        private Brush CheckColor(string src)
        {
            var converter = new System.Windows.Media.BrushConverter();
            Brush result = (Brush)converter.ConvertFromString("#B7DE4B");

            switch (src)
            {
                case "빨강":
                    result = Brushes.Red;
                    break;

                case "주황":
                    result = Brushes.Orange;
                    break;

                case "노랑":
                    result = Brushes.Yellow;
                    break;

                case "초록":
                    result = Brushes.Green;
                    break;

                case "파랑":
                    result = Brushes.Blue;
                    break;

                case "남색":
                    result = Brushes.Indigo;
                    break;

                case "보라":
                    result = Brushes.Purple;
                    break;
            }

            return result;
        }
    }
}