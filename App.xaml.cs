using System.Windows;

namespace Maeily_Windows
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        public MainWindow mainWindow = new MainWindow();
        private SignIn signIn = new SignIn();

        public void logIn()
        {
            signIn.Hide();
            mainWindow.Show();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            signIn.Show();
        }
    }
}