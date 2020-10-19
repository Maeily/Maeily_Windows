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
        private int my;
        private TextBlock text = new TextBlock();

        public Main()
        {
            InitializeComponent();
            Visiblity_Controller();
            Meal();
        }
        
        private void Meal()
        {
            string now = DateTime.Now.ToString("HH");

            if(double.Parse(now) >= 19 && double.Parse(now) < 8)
            {
                my = 0;
            }
            else if (double.Parse(now) >= 8 && double.Parse(now) < 13)
            {
                my = 1;
            }
            else
            {
                my = 2;
            }
            text.Text = LoadMeal.loadMeal.getMeal(my);
            meal.Children.Clear();
            meal.Children.Add(text);
            Visiblity_Controller();
        }

        private void RightButton_Click(object sender, RoutedEventArgs e)
        {
            my++;
            text.Text = LoadMeal.loadMeal.getMeal(my);
            meal.Children.Clear();
            meal.Children.Add(text);
            Visiblity_Controller();
        }

        private void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            my--;
            text.Text = LoadMeal.loadMeal.getMeal(my);
            meal.Children.Clear();
            meal.Children.Add(text);
            Visiblity_Controller();
        }

        private void Visiblity_Controller()
        {
            Right.Visibility = Visibility.Visible;
            Left.Visibility = Visibility.Visible;
            if (my == 2)
            {
                Right.Visibility = Visibility.Hidden;
            }
            else if(my == 0)
            {
                Left.Visibility = Visibility.Hidden;
            }
        }
    }
}
