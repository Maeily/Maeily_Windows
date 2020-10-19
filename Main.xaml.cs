using System;
using System.Collections.Generic;
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
            Meal();
        }
        
        private void Meal()
        {
            string now = DateTime.Now.ToString("HH");

            if(double.Parse(now) >= 19 && double.Parse(now) < 8)
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
            meal.Children.Clear();
            meal.Children.Add(text);
        }
    }
}
