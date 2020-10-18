using Maeily_Windows.Controls;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Maeily_Windows
{
    /// <summary>
    /// Channel_Settings.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Channel_Settings : Page
    {
        private List<CalendarContent> contents = new List<CalendarContent>();

        public Channel_Settings()
        {
            InitializeComponent();
            BtnAddContent.Click += new RoutedEventHandler(BtnAddContent_Click);
        }

        public void BtnAddContent_Click(object sender, RoutedEventArgs e)
        {
            if (TbContent.Visibility == Visibility.Hidden)
            {
                TbContent.Visibility = Visibility.Visible;
            }
            else
            {
                AddCalendar(TbContent.Text);
                TbContent.Visibility = Visibility.Hidden;
                TbContent.Text = null;
            }
        }

        private void AddCalendar(string name)
        {
            if (TbContent.Text != "")
            {
                CalendarContent content = new CalendarContent(1, name);

                contents.Add(content);
                ListSchedules.ItemsSource = contents;

                ListSchedules.Items.Refresh();
            }
            else
            {
                MessageBox.Show("입력 칸을 채워주세요!", "메일리");
            }
        }
    }
}