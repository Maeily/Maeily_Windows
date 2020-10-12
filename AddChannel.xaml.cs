using System.Windows.Controls;

namespace Maeily_Windows
{
    /// <summary>
    /// AddChannel.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AddChannel : Page
    {
        public AddChannel()
        {
            InitializeComponent();
            CbColor.SelectionChanged += CbColor_SelectionChanged;
        }

        private void CbColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CbColor.Foreground = (CbColor.SelectedItem as ComboBoxItem).Foreground;
        }
    }
}