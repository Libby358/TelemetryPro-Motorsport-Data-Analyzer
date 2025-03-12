using System;
using System.Collections.Generic;
using System.Data.SQLite;
using TelemetryPro.Models;

namespace TelemetryPro.Services
{
    public class DatabaseService
    {
        private const string ConnectionString = "Data Source=Data/TelemetryDatabase.db;Version=3;";

        public DatabaseService()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string createTableQuery = @"CREATE TABLE IF NOT EXISTS Telemetry (
                                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                                Speed REAL,
                                                RPM REAL,
                                                TireTemperature REAL)";
                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void SaveTelemetryData(TelemetryData data)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string insertQuery = "INSERT INTO Telemetry (Speed, RPM, TireTemperature) VALUES (@Speed, @RPM, @TireTemperature)";
                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Speed", data.Speed);
                    command.Parameters.AddWithValue("@RPM", data.RPM);
                    command.Parameters.AddWithValue("@TireTemperature", data.TireTemperature);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
