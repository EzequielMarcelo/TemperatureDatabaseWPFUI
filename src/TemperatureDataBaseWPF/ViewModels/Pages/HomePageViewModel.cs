using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView.Extensions;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using TemperatureDataBaseWPF.Services;

namespace TemperatureDataBaseWPF.ViewModels.Pages
{
    public partial class HomePageViewModel : ObservableObject
    {
        private SerialDataAcquisition _serialHandler;

        public HomePageViewModel(IService service)
        {
            _serialHandler = service.SerialHandler;
            _serialHandler.OnUpdateTemperature += SerialUpdateTemperature;

            Temperature = new ObservableValue()
            {
                Value = 20,
            };

            int innerRadius = 200;

            Series = GaugeGenerator.BuildSolidGauge(
                new GaugeItem(Temperature, series =>
                {
                    series.Fill = new SolidColorPaint(SKColors.YellowGreen);                    
                    series.IsHoverable = false;                  
                    series.InnerRadius = innerRadius;
                    series.DataLabelsPaint = new SolidColorPaint(SKColors.Red);
                    series.DataLabelsPosition = PolarLabelsPosition.ChartCenter;
                    series.DataLabelsSize = 60;
                    series.DataLabelsFormatter = x => "Temperature \r" + x.Coordinate.PrimaryValue.ToString("F2") + "ºC";
                }),

                new GaugeItem(GaugeItem.Background, series =>
                {
                    series.InnerRadius = innerRadius;
                    series.Fill = new SolidColorPaint(new SKColor(100, 181, 246, 90));
                }));
        }

        private void SerialUpdateTemperature(object? sender, double temperature)
        {
            Temperature.Value = temperature;
        }

        public IEnumerable<ISeries> Series { get; set; }
        public ObservableValue Temperature {  get; set; }
    }
}
