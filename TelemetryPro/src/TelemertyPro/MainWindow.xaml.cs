using System.Windows;

namespace TelemetryPro.Views
{
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = new ViewModels.MainViewModel();
        }
    }
}
