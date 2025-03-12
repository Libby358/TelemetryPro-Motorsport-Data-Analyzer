using System.Collections.Generic;
using System.Linq;
using TelemetryPro.Models;

namespace TelemetryPro.Services
{
    public class AnalysisService
    {
        public double CalculateAverageSpeed(List<TelemetryData> telemetryData)
        {
            return telemetryData.Average(t => t.Speed);
        }

        public double CalculateMaxRPM(List<TelemetryData> telemetryData)
        {
            return telemetryData.Max(t => t.RPM);
        }
    }
}
