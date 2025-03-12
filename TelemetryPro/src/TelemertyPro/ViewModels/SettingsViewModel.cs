using System.Windows.Input;
using TelemetryPro.Helpers;

namespace TelemetryPro.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private bool _isDarkModeEnabled;
        public bool IsDarkModeEnabled { get => _isDarkModeEnabled; set { _isDarkModeEnabled = value; OnPropertyChanged(); } }
        public ICommand SaveSettingsCommand { get; }

        public SettingsViewModel()
        {
            SaveSettingsCommand = new RelayCommand(SaveSettings);
        }

        private void SaveSettings()
        {
            // Save settings logic here
        }
    }
}
