< Window x: Class = "TelemetryPro.Views.MainView"
        xmlns = "http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns: x = "http://schemas.microsoft.com/winfx/2006/xaml"
        Title = "TelemetryPro" Height = "500" Width = "800" >
    < Grid >
        < TextBlock Text = "TelemetryPro - Motorsport Data Analyzer"
                   HorizontalAlignment = "Center" VerticalAlignment = "Top" FontSize = "20" />
        < Button Content = "Start Telemetry" Command = "{Binding StartTelemetryCommand}"
                HorizontalAlignment = "Center" VerticalAlignment = "Center" />
    </ Grid >
</ Window >

