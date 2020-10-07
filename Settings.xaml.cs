using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Maeily_Windows
{
    /// <summary>
    /// Settings.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Settings : Page
    {
        public Settings()
        {
            InitializeComponent();
            BtnSubmit.MouseEnter += BtnSubmit_MouseEnter;
            BtnSubmit.MouseLeave += BtnSubmit_MouseLeave;
        }

        private void BtnSubmit_MouseLeave(object sender, MouseEventArgs e)
        {
            var Bc = new BrushConverter();
            BtnSubmit.BorderBrush = (Brush)Bc.ConvertFrom("#F1F1F1");
        }

        private void BtnSubmit_MouseEnter(object sender, MouseEventArgs e)
        {
            BtnSubmit.BorderBrush = Brushes.Blue;
        }
    }
}