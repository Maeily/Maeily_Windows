using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
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
            BtnSubmit.Click += BtnSubmit_Click;
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            FileInfo fileInfo = new FileInfo("Channel/" + TbChannelName.Text + ".txt");
            DirectoryInfo directory = new DirectoryInfo("Channel");
            FileStream fs;
            string isPublic = "False";

            if (TbChannelName.Text == "" || CbColor.Text == "")
            {
                MessageBox.Show("입력 칸을 채워주세요!", "메일리");
                return;
            }

            if (directory.Exists == false)
            {
                directory.Create();
            }

            if (fileInfo.Exists == false)
            {
                fs = fileInfo.Create();
                fs.Close();
            }
            else
            {
                MessageBox.Show("이미 존재하는 채널입니다!", "메일리");
                TbChannelName.Text = null;
                CbColor.SelectedIndex = 0;
                ChkIsPublic.IsChecked = false;
                return;
            }

            if (ChkIsPublic.IsChecked == true)
            {
                isPublic = "True";
            }

            StreamWriter writer = new StreamWriter("Channel/" + TbChannelName.Text + ".txt");
            JObject jObject = new JObject();

            jObject.Add("channel_name", TbChannelName.Text);
            jObject.Add("channel_code", "채널 코드");
            jObject.Add("color", CbColor.Text);
            jObject.Add("isPublic", isPublic);

            writer.Write(JsonConvert.SerializeObject(jObject));
            writer.Flush();
            writer.Close();

            TbChannelName.Text = null;
            CbColor.SelectedItem = null;
            ChkIsPublic.IsChecked = false;
            MessageBox.Show("채널이 생성되었습니다!", "메일리");
            return;
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
            if (CbColor.SelectedItem != null) {
                CbColor.Foreground = (CbColor.SelectedItem as ComboBoxItem).Foreground;
            }
        }
    }
}