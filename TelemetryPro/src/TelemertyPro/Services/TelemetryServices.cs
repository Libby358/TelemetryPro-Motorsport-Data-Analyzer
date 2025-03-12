using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using TelemetryPro.Models;

namespace TelemetryPro.Services
{
    public class TelemetryService
    {
        private UdpClient _client;
        private const int Port = 5000;
        public event Action<TelemetryData> TelemetryReceived;

        public void StartListening()
        {
            _client = new UdpClient(Port);
            _client.BeginReceive(OnDataReceived, null);
        }

        private void OnDataReceived(IAsyncResult result)
        {
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, Port);
            byte[] data = _client.EndReceive(result, ref endpoint);
            string telemetryString = Encoding.UTF8.GetString(data);

            var telemetry = ParseTelemetryData(telemetryString);
            TelemetryReceived?.Invoke(telemetry);

            _client.BeginReceive(OnDataReceived, null);
        }

        private TelemetryData ParseTelemetryData(string data)
        {
            var values = data.Split(',');
            return new TelemetryData
            {
                Speed = double.Parse(values[0]),
                RPM = double.Parse(values[1]),
                TireTemperature = double.Parse(values[2])
            };
        }
    }
}
