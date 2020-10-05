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
        private List<StackPanel> Users = new List<StackPanel>();

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
            StackPanel stackPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            Image image = new Image();
            image.Source = imgSrc;
            image.Margin = new Thickness(40, 10, 30, 10);
            image.Width = 40;
            image.Height = 40;
            TextBlock textBlock = new TextBlock()
            {
                FontWeight = FontWeights.Bold,
                Text = userInfo,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                FontSize = 15
            };
            stackPanel.Children.Add(image);
            stackPanel.Children.Add(textBlock);
            Users.Add(stackPanel);
            Userlist.ItemsSource = Users;
            Userlist.Items.Refresh();
        }
    }
}