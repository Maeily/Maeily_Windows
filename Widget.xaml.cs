using System;
using System.Windows;

namespace Maeily_Windows
{
    /// <summary>
    /// Widget.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Widget : Window
    {
        public Widget()
        {
            InitializeComponent();
            Loaded += WidgetLoaded;
        }

        private void WidgetLoaded(object sender, RoutedEventArgs e)
        {
            InitWorkerW();
            InitOnDisplaySettingChanged();
            ShowOnWorkerW();
            FillDisplay();

            TxBTodayDate.Text = DateTime.UtcNow.ToString("MM월 dd일 dddd");
            TxBTodaySchedule.Text = "밥 먹기";
        }
    }
}