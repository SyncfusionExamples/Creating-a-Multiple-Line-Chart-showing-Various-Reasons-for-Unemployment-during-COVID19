using Syncfusion.UI.Xaml.Charts;
using System.Windows;
using System.Windows.Input;

namespace COVID19_MultiLine_Chart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumericalAxis_LabelCreated(object sender, LabelCreatedEventArgs e)
        {
            if (e.AxisLabel is ChartAxisLabel label && label.LabelContent is string content && content != "0")
            {
                var value = double.Parse(content) / 1000000;
                label.LabelContent = value.ToString() + "M";
            }
        }

        private void SfChart_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is ChartSeries series)
            {
                foreach (var chartSeries in chart.Series)
                {
                    if (chartSeries != series)
                    {
                        chartSeries.StrokeThickness = 2;
                    }
                    else
                    {
                        series.StrokeThickness = 4;
                    }
                }
            }
        }

        private void FastLineSeries_MouseLeave(object sender, MouseEventArgs e)
        {
            foreach (var chartSeries in chart.Series)
            {
                chartSeries.StrokeThickness = 2;
            }
        }
    }
}
