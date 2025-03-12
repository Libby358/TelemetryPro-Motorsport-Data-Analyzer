using System;
using System.Windows.Input;
using TelemetryPro.Helpers;
using TelemetryPro.Services;

namespace TelemetryPro.ViewModels
{
    public class MainViewModel
    {
        private readonly TelemetryService _telemetryService;

        public ICommand StartTelemetryCommand { get; }

        public MainViewModel()
        {
            _telemetryService = new TelemetryService();
            StartTelemetryCommand = new RelayCommand(StartTelemetry);
        }

        private void StartTelemetry()
        {
            _telemetryService.Connect();
        }
    }
}
