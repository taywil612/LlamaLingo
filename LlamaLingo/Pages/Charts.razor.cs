using LlamaLingo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Diagram;
using Syncfusion.Blazor.Layouts;
using Syncfusion.DocIO.DLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using shapes = Syncfusion.Blazor.Diagram.NodeShapes;

namespace LlamaLingo.Pages
{
	public partial class Charts
	{
		private Theme Theme { get; set; }

		private readonly string[] palettes = new string[] { "#61EFCD", "#CDDE1F", "#FEC200", "#CA765A", "#2485FA", "#F57D7D", "#C152D2",
		"#8854D9", "#3D4EB8", "#00BCD7","#4472c4", "#ed7d31", "#ffc000", "#70ad47", "#5b9bd5", "#c1c1c1", "#6f6fe2", "#e269ae", "#9e480e", "#997300" };

		SfDiagramComponent diagram;

		public List<int> WeekIds;

		public int selectedWeek;

		private int totalEntries = 0;
		private bool IsLoading { get; set; } = true;

		private List<List<WeeklyPypeDetail>> weeklyPypeDetails;

		public List<Noun> nouns;

		public async void getWeekIds(int podID)
		{
			WeekIds = await db.Set<WeeklyPypeDetail>().Where(x=> x.Project == podID).Select(x => x.WeekId).Distinct().ToListAsync();

			StateHasChanged();
		}

		public async void ChangeWeek(Syncfusion.Blazor.DropDowns.ChangeEventArgs<int, int> args)
		{
			selectedWeek = args.ItemData;

			try
			{
				totalEntries = 0;

				weeklyPypeDetails = await BuildCharts(SelectedInfo.CurrentPod.PodId, selectedWeek);

			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
			}

			StateHasChanged();
		}

		public async System.Threading.Tasks.Task<List<List<WeeklyPypeDetail>>> BuildCharts(int podID, int weekId)
		{
			//Create a list containing all of the data to build the Radar Chart.
			List<List<WeeklyPypeDetail>> allChartData = new List<List<WeeklyPypeDetail>>();

			nouns = await db.Set<Noun>().Where(s => s.PodIdFk == podID).ToListAsync();

			foreach (Noun noun in nouns)
			{
				List<WeeklyPypeDetail> weeklyPypeDetails = await db.Set<WeeklyPypeDetail>().Where(s => s.NounLabel == noun.NounLabel && s.WeekId == weekId).ToListAsync();

				if (!weeklyPypeDetails.IsNullOrEmpty())
				{
					totalEntries += weeklyPypeDetails.Count;
					allChartData.Add(weeklyPypeDetails);
				}
			}

			return allChartData;
		}

		//Defines diagrams's nodes collection
		DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
		protected override void OnInitialized()
		{
			if (SelectedInfo.CurrentPod != null)
			{
				try
				{
					getWeekIds(SelectedInfo.CurrentPod.PodId);
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Error: {ex.Message}");
				}
			}

			IsLoading = false;

			Node pieChartNode = new Node()
			{
				ID = "pieChartNode",
				Width = 1050,
				Height = 430,
				OffsetX = 600,
				Annotations = new DiagramObjectCollection<ShapeAnnotation>() { new ShapeAnnotation() { Constraints = AnnotationConstraints.ReadOnly } },
				Constraints = NodeConstraints.Default & ~NodeConstraints.Resize & ~NodeConstraints.Rotate & ~NodeConstraints.Select,
				OffsetY = 380,
				Shape = new Syncfusion.Blazor.Diagram.Shape() { Type = shapes.HTML }
			};
			Node pyramidChartNode = new Node()
			{
				ID = "pyramidChartNode",
				Width = 512,
				Height = 408,
				OffsetX = 870,
				Constraints = NodeConstraints.Default & ~NodeConstraints.Resize & ~NodeConstraints.Rotate & ~NodeConstraints.Select,
				OffsetY = 380,
				Shape = new Syncfusion.Blazor.Diagram.Shape() { Type = shapes.HTML },
			};
			Node barChartNode = new Node()
			{
				ID = "barChartNode",
				Width = 512,
				Height = 408,
				OffsetX = 325,
				Constraints = NodeConstraints.Default & ~NodeConstraints.Resize & ~NodeConstraints.Rotate & ~NodeConstraints.Select,
				OffsetY = 1250,
				Shape = new Syncfusion.Blazor.Diagram.Shape() { Type = shapes.HTML }
			};
			Node funnelChartNode = new Node()
			{
				ID = "funnelChartNode",
				Width = 512,
				Height = 408,
				OffsetX = 870,
				Constraints = NodeConstraints.Default & ~NodeConstraints.Resize & ~NodeConstraints.Rotate & ~NodeConstraints.Select,
				OffsetY = 810,
				Shape = new Syncfusion.Blazor.Diagram.Shape() { Type = shapes.HTML }
			};
			Node radarChartNode = new Node()
			{
				ID = "radarChartNode",
				Width = 512,
				Height = 408,
				OffsetX = 325,
				Constraints = NodeConstraints.Default & ~NodeConstraints.Resize & ~NodeConstraints.Rotate & ~NodeConstraints.Select,
				OffsetY = 810,
				Shape = new Syncfusion.Blazor.Diagram.Shape() { Type = shapes.HTML }
			};
			TextStyle textStyle = new TextStyle()
			{
				FontSize = 16,
				Color = "#797979",
				Bold = true
			};
			ShapeAnnotation shapeAnnotation = new ShapeAnnotation()
			{
				Content = "CHARTS",
				Style = textStyle
			};
			Node textNode = new Node()
			{
				ID = "textNode",
				Width = 250,
				Height = 30,
				OffsetX = 153,
				Constraints = NodeConstraints.Default & ~NodeConstraints.Resize & ~NodeConstraints.Rotate,
				OffsetY = 20,
				Style = new ShapeStyle() { Fill = "Transparent", StrokeColor = "Transparent" },
				Annotations = new DiagramObjectCollection<ShapeAnnotation>() { shapeAnnotation }
			};
			Node numberOfEntriesNode = new Node()
			{
				ID = "numberOfEntriesNode",
				Width = 250,
				Height = 100,
				OffsetX = 200,
				Constraints = NodeConstraints.Default & ~NodeConstraints.Select,
				//Style = new ShapeStyle() { StrokeColor = "Transparent" },
				OffsetY = 90,
				Shape = new Syncfusion.Blazor.Diagram.Shape() { Type = shapes.HTML }
			};
			Node weekCountNode = new Node()
			{
				ID = "weekCountNode",
				Width = 250,
				Height = 100,
				OffsetX = 460,
				Constraints = NodeConstraints.Default & ~NodeConstraints.Select,
				OffsetY = 90,
				Style = new ShapeStyle() { StrokeColor = "Transparent" },
				Shape = new Syncfusion.Blazor.Diagram.Shape() { Type = shapes.HTML }
			};
			Node weekNode = new Node()
			{
				ID = "weekNode",
				Width = 250,
				Height = 100,
				OffsetX = 720,
				Constraints = NodeConstraints.Default & ~NodeConstraints.Select,
				OffsetY = 90,
				Style = new ShapeStyle() { StrokeColor = "Transparent" },
				Shape = new Syncfusion.Blazor.Diagram.Shape() { Type = shapes.HTML }
			};

			nodes.Add(pieChartNode);
			nodes.Add(pyramidChartNode);
			nodes.Add(barChartNode);
			nodes.Add(funnelChartNode);
			nodes.Add(radarChartNode);
			nodes.Add(textNode);
			nodes.Add(numberOfEntriesNode);
			nodes.Add(weekCountNode);
			nodes.Add(weekNode);
		}
		private void OnCreated()
		{
			FitOptions mobileoptions = new FitOptions() { Mode = FitMode.Both, Region = DiagramRegion.Content };
			diagram.FitToPage(mobileoptions);
		}
	}
}