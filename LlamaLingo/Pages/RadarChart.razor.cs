using LlamaLingo.Models;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor.Gantt;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LlamaLingo.Pages
{
    public partial class RadarChart
    {
		private bool IsLoading { get; set; } = true;

		private List<List<WeeklyPypeDetail>> weeklyPypeDetails;

        public List<Noun> nouns;

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            if (SelectedPod.CurrentPod != null)
            {
                try
                {
                    weeklyPypeDetails = await BuildRadarChart(SelectedPod.CurrentPod.PodId);

                    //ProjectName = ganttTaskList.First().ProjectName;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            else
            {
                weeklyPypeDetails = new List<List<WeeklyPypeDetail>>();
            }

			IsLoading = false;
        }

        public async System.Threading.Tasks.Task<List<List<WeeklyPypeDetail>>> BuildRadarChart(int podID)
        {
            //Create a list containing all of the data to build the Radar Chart.
            List<List<WeeklyPypeDetail>> allChartData = new List<List<WeeklyPypeDetail>>();
            
            nouns = await db.Set<Noun>().Where(s => s.PodIdFk == podID).ToListAsync();

            foreach(Noun noun in nouns)
            {
				allChartData.Add(await db.Set<WeeklyPypeDetail>().Where(s => s.NounLabel == noun.NounLabel).ToListAsync());
            }

            return allChartData;
        }

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