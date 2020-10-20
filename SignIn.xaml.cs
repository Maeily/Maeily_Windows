using Newtonsoft.Json.Linq;
using System.IO;
using System.Windows;

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
            Loaded += SignIn_Loaded;
            BtnSubmit.Click += BtnSubmit_Click;
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string userID = string.Empty;
            if (IdBox.Text.Equals("") || PasswordBox.Password.Equals(""))
            {
                MessageBox.Show("입력 칸을 채워주세요!", "메일리");
            }
            else
            {
                StreamReader reader = new StreamReader("Users.txt");
                JArray jArray = JArray.Parse(reader.ReadToEnd());

                foreach (JObject item in jArray)
                {
                    if (IdBox.Text.Equals(item["id"].ToString()) &&
                        PasswordBox.Password.Equals(item["pwd"].ToString()))
                    {
                        userID = item["id"].ToString();

                        MainWindow main = new MainWindow();

                        main.LoadUser(item["id"].ToString());
                        main.Show();
                        Close();

                        return;
                    }
                }

                MessageBox.Show("존재하지 않는 유저입니다.", "메일리");
                return;
            }
        }

        private void SignIn_Loaded(object sender, RoutedEventArgs e)
        {
            FileIO fileIO = new FileIO();

            if (!fileIO.CheckFile("Users.txt"))
            {
                fileIO.WriteJObject("Users.txt", "[]");
            }
        }
    }
}