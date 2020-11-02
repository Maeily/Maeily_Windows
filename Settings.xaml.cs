using System.Windows.Controls;

namespace Maeily_Windows
{
    /// <summary>
    /// Settings.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Settings : Page
    {
        private static Settings instance;

        public static Settings Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Settings();
                }

                return instance;
            }
        }

        private Settings()
        {
            InitializeComponent();
        }
    }
}