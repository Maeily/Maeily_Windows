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
    /// Channel_Settings.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Channel_Settings : Page
    {

        public Channel_Settings()
        {
            InitializeComponent();
        }

        public bool isalready = false;


        public void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtbox.Visibility == Visibility.Hidden)
            {
                txtbox.Visibility = Visibility.Visible;
            }
            else
            {
                AddCalendar(txtbox.Text);
                txtbox.Visibility = Visibility.Hidden;
            }
        }

        private void AddCalendar(string name)
        {
            isalready = false;
            StackPanel stackPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Width = 200,
                Margin = new Thickness(10)
            };
            Rectangle rectangle = new Rectangle();
            rectangle.Width = 10;
            rectangle.Height = 10;
            rectangle.Margin = new Thickness(60, 0, 0, 0);
            rectangle.Fill = Brushes.Black;
            TextBlock textBlock = new TextBlock()
            {
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(10, 0, 0, 0),
                Text = name
            };
            stackPanel.Children.Add(rectangle);
            stackPanel.Children.Add(textBlock);
            CalendarList.Children.Add(stackPanel);
        }

    }
}
