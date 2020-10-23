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
            ButtomVisibility();
        }

        private void ButtomVisibility()
        {
            if(curMealNum == 0)
            {
                Lbutton.Visibility = Visibility.Hidden;
            }
            else
            {
                Lbutton.Visibility = Visibility.Visible;
            }

            if (curMealNum == 2)
            {
                Rbutton.Visibility = Visibility.Hidden;
            }
            else
            {
                Rbutton.Visibility = Visibility.Visible;
            }
        }

        private void MainLoaded(object sender, RoutedEventArgs e)
        {
            ((App) Application.Current).LoadChannel(ref UGridChannels);
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
            curMealNum++;
            ChangeLbTimeText(curMealNum);
            meal.Children.Clear();
            text.Text = curMeal[curMealNum];
            meal.Children.Add(text);
            ButtomVisibility();
        }

        private void LeftButtonClick(object sender, RoutedEventArgs e)
        {
            curMealNum--;
            ChangeLbTimeText(curMealNum);
            meal.Children.Clear();
            text.Text = curMeal[curMealNum];
            meal.Children.Add(text);
            ButtomVisibility();
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