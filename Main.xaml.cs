using Maeily_Windows.Controls;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Maeily_Windows
{
    /// <summary>
    /// Main.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Main : Page
    {
        private int myPage;
        private TextBlock text = new TextBlock();

        public Main()
        {
            InitializeComponent();
            text.FontWeight = FontWeights.Bold;
            text.HorizontalAlignment = HorizontalAlignment.Center;
            Loaded += Main_Loaded;
            Meal();
        }

        private void Main_Loaded(object sender, RoutedEventArgs e)
        {
            loadChannel();
        }

        public void loadChannel()
        {
            DirectoryInfo directory = new DirectoryInfo("Channel");
            FileInfo[] fileInfos = directory.GetFiles("*.txt");
            StreamReader streamReader = null;
            JArray jArray = new JArray();
            bool isJoined = false;

            if (directory.Exists)
            {
                if (fileInfos.Length != 0)
                {
                    foreach (var item in fileInfos)
                    {
                        streamReader = new StreamReader("Channel/UserList/" + item.Name);
                        jArray = JArray.Parse(streamReader.ReadToEnd());

                        foreach (JObject data in jArray)
                        {
                            if (data["id"].ToString().Equals(((App)Application.Current).userID))
                            {
                                isJoined = true;
                                break;
                            }
                        }

                        if (isJoined)
                        {
                            ChannelUnit channelUnit = new ChannelUnit(item.Name.Replace(".txt", ""));
                            channelUnit.Margin = new Thickness(5, 10, 5, 10);

                            UGridChannels.Children.Add(channelUnit);
                        }
                    }
                }
            }
        }

        private void Meal()
        {
            string now = DateTime.Now.ToString("HH");

            if (double.Parse(now) >= 19 && double.Parse(now) < 8)
            {
                myPage = 2;
            }
            else if (double.Parse(now) >= 8 && double.Parse(now) < 13)
            {
                myPage = 1;
            }
            else
            {
                myPage = 2;
            }
            text.Text = LoadMeal.loadMeal.getMeal(myPage);
            ChangeLbTimeText(myPage);
            meal.Children.Clear();
            meal.Children.Add(text);
        }

        private void RightButton_Click(object sender, RoutedEventArgs e)
        {
            if (myPage >= 2)
            {
                return;
            }
            myPage++;
            text.Text = LoadMeal.loadMeal.getMeal(myPage);
            ChangeLbTimeText(myPage);
            meal.Children.Clear();
            meal.Children.Add(text);
        }

        private void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            if (myPage <= 0)
            {
                return;
            }
            myPage--;
            text.Text = LoadMeal.loadMeal.getMeal(myPage);
            ChangeLbTimeText(myPage);
            meal.Children.Clear();
            meal.Children.Add(text);
        }

        private void ChangeLbTimeText(int n)
        {
            switch (n)
            {
                case 0:
                    LbTime.Content = "아침";
                    break;

                case 1:
                    LbTime.Content = "점심";
                    break;

                case 2:
                    LbTime.Content = "저녁";
                    break;
            }
        }
    }
}