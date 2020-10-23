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
        private int curMealNum;
        private string[] curMeal = new string[3];
        private TextBlock text = new TextBlock();

        public Main()
        {
            InitializeComponent();
            Loaded += MainLoaded;
            MakeMeal();
            Meal();
        }

        private void MainLoaded(object sender, RoutedEventArgs e)
        {
            LoadChannel();
        }

        public void LoadChannel()
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

                            isJoined = false;
                            UGridChannels.Children.Add(channelUnit);
                        }
                    }
                }
            }
        }

        private void MakeMeal()
        {
            curMeal[0] = LoadMeal.loadMeal.GetMeal(0);
            curMeal[1] = LoadMeal.loadMeal.GetMeal(1);
            curMeal[2] = LoadMeal.loadMeal.GetMeal(2);
        }

        private void Meal()
        {
            string now = DateTime.Now.ToString("HH");

            if (double.Parse(now) >= 19 && double.Parse(now) < 8)
            {
                curMealNum = 0;
            }
            else if (double.Parse(now) >= 8 && double.Parse(now) < 13)
            {
                curMealNum = 1;
            }
            else
            {
                curMealNum = 2;
            }
            ChangeLbTimeText(curMealNum);
            meal.Children.Clear();
            text.Text = curMeal[curMealNum];
            meal.Children.Add(text);
        }

        private void RightButtonClick(object sender, RoutedEventArgs e)
        {
            if (curMealNum >= 2)
            {
                return;
            }
            curMealNum++;
            ChangeLbTimeText(curMealNum);
            meal.Children.Clear();
            text.Text = curMeal[curMealNum];
            meal.Children.Add(text);
        }

        private void LeftButtonClick(object sender, RoutedEventArgs e)
        {
            if (curMealNum <= 0)
            {
                return;
            }
            curMealNum--;
            ChangeLbTimeText(curMealNum);
            meal.Children.Clear();
            text.Text = curMeal[curMealNum];
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