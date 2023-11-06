using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView.Extensions;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace TemperatureDataBaseWPF.ViewModels.Pages
{
    public partial class HomePageViewModel : ObservableObject
    {
        public HomePageViewModel()
        {
            Temperature = new ObservableValue()
            {
                Value = 20,
            };

            int innerRadius = 200;

            Series = GaugeGenerator.BuildSolidGauge(
                new GaugeItem(Temperature, series =>
                {
                    series.Fill = new SolidColorPaint(SKColors.YellowGreen);
                    series.DataLabelsSize = 50;
                    series.IsHoverable = false;
                    series.DataLabelsPaint = new SolidColorPaint(SKColors.Red);
                    series.DataLabelsPosition = PolarLabelsPosition.ChartCenter;
                    series.InnerRadius = innerRadius;
                    series.DataLabelsFormatter = x => x.Coordinate.PrimaryValue + "ºC";
                 }),
                new GaugeItem(GaugeItem.Background, series =>
                {
                    series.InnerRadius = innerRadius;
                    series.Fill = new SolidColorPaint(new SKColor(100, 181, 246, 90));
                }));
        }
        public IEnumerable<ISeries> Series { get; set; }
        public ObservableValue Temperature {  get; set; }
    }
}
