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
        private FileInfo fileInfo;
        private OpenFileDialog openFileDialog = new OpenFileDialog();
        private string channelName = string.Empty;
        private FileIO fileIO = new FileIO();

        public AddChannel()
        {
            InitializeComponent();
            CbColor.SelectionChanged += CbColor_SelectionChanged;
            ImgChannel.MouseDown += ImgChannel_MouseDown;
            BtnSubmit.Click += BtnSubmit_Click;
            Loaded += AddChannel_Loaded;
        }

        private void AddChannel_Loaded(object sender, RoutedEventArgs e)
        {
            DirectoryInfo directory = new DirectoryInfo("Channel/Schedules");

            if (!directory.Exists)
            {
                directory.Create();
            }
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string file = string.Empty;
            fileInfo = new FileInfo("Channel/" + TbChannelName.Text + ".txt");
            JObject jObject = new JObject();
            FileStream fs;

            string isPublic = "False";

            if (TbChannelName.Text == "" || CbColor.Text == "")
            {
                MessageBox.Show("입력 칸을 채워주세요!", "메일리");
                return;
            }
            channelName = TbChannelName.Text;

            if (fileInfo.Exists)
            {
                MessageBox.Show("이미 존재하는 채널입니다!", "메일리");
                TbChannelName.Text = null;
                CbColor.SelectedIndex = 0;
                ChkIsPublic.IsChecked = false;
                return;
            }

            fileIO.AddDirectory("Channel");
            fileIO.AddDirectory("Channel/Schedules");
            fileIO.AddDirectory("Channel/Resources");
            fileIO.AddDirectory("Channel/UserList");

            fs = File.Create("Channel/Schedules/" + channelName + ".txt");
            fs.Close();
            fs = File.Create("Channel/" + channelName + ".txt");
            fs.Close();

            if (ChkIsPublic.IsChecked == true)
            {
                isPublic = "True";
            }

            jObject.Add("channel_name", TbChannelName.Text);
            jObject.Add("channel_code", "채널 코드");
            jObject.Add("color", CbColor.Text);
            jObject.Add("isPublic", isPublic);

            if (openFileDialog.FileName != "")
            {
                file = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                File.Copy(openFileDialog.FileName.Replace(".txt", ".jpg"),
                    @"Channel/Resources/" + TbChannelName.Text + ".jpg", true);
                ImgChannel.Source = new BitmapImage(
                    new Uri(@"Resources/AddBtn.png", UriKind.Relative));
            }
            else
            {
                jObject.Add("file_name", file);
            }

            fileIO.WriteJObject("Channel/" + channelName + ".txt", JsonConvert.SerializeObject(jObject));
            fileIO.WriteJObject("Channel/Schedules/" + channelName + ".txt", "[]");
            fileIO.WriteJObject("Channel/UserList/" + channelName + ".txt", "[]");

            TbChannelName.Text = null;
            CbColor.SelectedItem = null;
            ChkIsPublic.IsChecked = false;
            MessageBox.Show("채널이 생성되었습니다!", "메일리");
            return;
        }

        private void ImgChannel_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            openFileDialog.Filter = "JPEG File (*.jpg)|*.jpg";
            openFileDialog.ShowDialog();

            if (openFileDialog.FileName != "")
            {
                ImgChannel.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        private void CbColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CbColor.SelectedItem != null)
            {
                CbColor.Foreground = (CbColor.SelectedItem as ComboBoxItem).Foreground;
            }
        }

    }
}