using System;
using TelemetryPro.Models;

namespace TelemetryPro.Services
{
    public class DataAcquisitionService
    {
        public event Action<TelemetryData> NewTelemetryData;

        public void ProcessIncomingData(TelemetryData data)
        {
            if (IsValid(data))
            {
                NewTelemetryData?.Invoke(data);
            }
        }

        private bool IsValid(TelemetryData data)
        {
            return data.Speed >= 0 && data.RPM >= 0 && data.TireTemperature >= 0;
        }
    }
}
