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

        private void TextBox_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TextBox txtbox = sender as TextBox;
            txtbox.SelectionStart = 0;
        }

        private void TextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            char keyCode = (char)e.Key;
            if (!char.IsDigit(keyCode))
            {

            }

            TextBox txtbox = sender as TextBox;
            if (string.Compare(txtbox.Text, "아이디를 입력해주세요") == 0 || string.Compare(txtbox.Text, "비밀번호를 입력해주세요") == 0)
            {
                txtbox.Text = "";
            }
        }

        private void TextBox_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }
    }
}