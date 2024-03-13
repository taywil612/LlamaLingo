using LlamaLingo.Models;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LlamaLingo.Pages
{
	public partial class GanttChart
    {
        private bool IsLoading { get; set; } = true;
        private string ProjectName { get; set; } = "";

        private string DurationUnit { get; set; } = "minutes";

        private List<GanttTaskLoad> ganttTaskList;

        private readonly string[] Searchfields = new string[] {
            "Id",
            "String",
            "Sdate",
            "Edate",
            "Duration",
            "Progress",
            "Parentid"
        };

		protected override async System.Threading.Tasks.Task OnInitializedAsync()
		{
            try
            {
                ganttTaskList = await BuildGanttTree();

                ProjectName = ganttTaskList.First().ProjectName;
            }
            catch(Exception ex)
            {
				Console.WriteLine($"Error: {ex.Message}");
			}

            IsLoading = false;
		}

		public async System.Threading.Tasks.Task <List<GanttTaskLoad>> BuildGanttTree()
        {
            //Create a list containing all of the data in the SyncGantt Table.
            List<GanttTaskLoad> allTasks = await db.Set<GanttTaskLoad>().ToListAsync();

            //Add a list of subtasks to each tasks.
            foreach (var task in allTasks)
            {
                task.SubTasks =  allTasks.Where(s => s.Parentid == task.Id && s.Id != s.Parentid).ToList();

				//Set random values for testing purposes.
				// {
				task.Duration = "1";
                task.Duration += DurationUnit;
                
                task.Progress = "1";
                // }
            }

            //Create a list of only parent tasks.
            List<GanttTaskLoad> parentTasks = allTasks.Where(s => s.Id == s.Parentid).ToList();

            return parentTasks;
        }
    }
}