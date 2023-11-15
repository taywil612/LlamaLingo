using System.Collections.Generic;

namespace LlamaLingo.Pages
{
    public partial class RadarChart
    {
        public class PolarLineChartData
        {
            public string xValue { get; set; }
            public double yValue { get; set; }
            public double yValue1 { get; set; }
        }

        public List<PolarLineChartData> dataSource = new List<PolarLineChartData>
        {
            new PolarLineChartData
            {
                xValue = "Jan",
                yValue = -7.1,
                yValue1 = -17.4
            },
            new PolarLineChartData
            {
                xValue = "Feb",
                yValue = -3.7,
                yValue1 = -15.6
            },
            new PolarLineChartData
            {
                xValue = "Mar",
                yValue = 0.8,
                yValue1 = -12.3
            },
            new PolarLineChartData
            {
                xValue = "Apr",
                yValue = 6.3,
                yValue1 = -5.3
            },
            new PolarLineChartData
            {
                xValue = "May",
                yValue = 13.3,
                yValue1 = 1.0
            },
            new PolarLineChartData
            {
                xValue = "Jun",
                yValue = 18.0,
                yValue1 = 6.9
            },
            new PolarLineChartData
            {
                xValue = "Jul",
                yValue = 19.8,
                yValue1 = 9.4
            },
            new PolarLineChartData
            {
                xValue = "Aug",
                yValue = 18.1,
                yValue1 = 7.6
            },
            new PolarLineChartData
            {
                xValue = "Sep",
                yValue = 13.1,
                yValue1 = 2.6
            },
            new PolarLineChartData
            {
                xValue = "Oct",
                yValue = 4.1,
                yValue1 = -4.9
            },
            new PolarLineChartData
            {
                xValue = "Nov",
                yValue = -3.8,
                yValue1 = -13.4
            },
            new PolarLineChartData
            {
                xValue = "Dec",
                yValue = -6.8,
                yValue1 = -16.4
            },
        };
    }
}