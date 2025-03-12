using LiveCharts;
using LiveCharts.Wpf;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TelemetryPro.ViewModels
{
    public class DashboardViewModel : INotifyPropertyChanged
    {
        private double _actualCost;
        private double _performanceRatio;
        private double _projectedCost;

        public double ActualCost
        {
            get => _actualCost;
            set { _actualCost = value; OnPropertyChanged(); }
        }

        public double PerformanceRatio
        {
            get => _performanceRatio;
            set { _performanceRatio = value; OnPropertyChanged(); }
        }

        public double ProjectedCost
        {
            get => _projectedCost;
            set { _projectedCost = value; OnPropertyChanged(); }
        }

        public SeriesCollection ProjectPhaseData { get; set; }
        public SeriesCollection ProjectCompletionData { get; set; }

        public DashboardViewModel()
        {
            ActualCost = 46660;
            PerformanceRatio = 0.89;
            ProjectedCost = 41579;

            ProjectPhaseData = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Completed",
                    Values = new ChartValues<double> { 50, 40, 30 }
                },
                new ColumnSeries
                {
                    Title = "Remaining",
                    Values = new ChartValues<double> { 30, 20, 10 }
                }
            };

            ProjectCompletionData = new SeriesCollection
            {
                new PieSeries { Title = "Planning", Values = new ChartValues<double> { 20 } },
                new PieSeries { Title = "Execution", Values = new ChartValues<double> { 40 } },
                new PieSeries { Title = "Testing", Values = new ChartValues<double> { 30 } }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

