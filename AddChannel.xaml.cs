using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Maeily_Windows
{
    /// <summary>
    /// AddChannel.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AddChannel : Page
    {
        public AddChannel()
        {
            InitializeComponent();
            CbColor.SelectionChanged += CbColor_SelectionChanged;
            ImgChannel.MouseDown += ImgChannel_MouseDown;
        }

        private void ImgChannel_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPEG File (*.jpg)|*.jpg|PNG File (*.png)|*.png|BITMAP (*bmp)|*.bmp";
            openFileDialog.ShowDialog();

            if (openFileDialog.FileName != "")
            {
                ImgChannel.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        private void CbColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CbColor.Foreground = (CbColor.SelectedItem as ComboBoxItem).Foreground;
        }
    }
}