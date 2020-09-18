using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Maeily_Windows
{
    /// <summary>
    /// SignIn.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SignIn : Window
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for(int i=0; i<IdBox.Text.Length; i++)
            {
                if(!char.IsDigit(IdBox.Text[i]))
            }
        }
    }
}