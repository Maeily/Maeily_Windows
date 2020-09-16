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
            Loaded += Widget_Loaded;
        }

        private void Widget_Loaded(object sender, RoutedEventArgs e)
        {
            InitWorkerW();
            InitOnDisplaySettingChanged();
            ShowOnWorkerW();
            FillDisplay();
        }
    }
}