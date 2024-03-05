using LlamaLingo.Models;
using Syncfusion.Blazor.Data;
using System.Collections.Generic;
using System.Linq;

namespace LlamaLingo.Pages
{
	public partial class GanttChart
    {
        //IEnumerable<LlamaLingo.Models.Gantt> GanttList;
        //public string[] Searchfields = new string[] { 
        //    "GanttId", 
        //    "GanttLabel", 
        //    "GanttStartDate", 
        //    "GanttFinishDate", 
        //    "GanttDuration", 
        //    "GanttProgress", 
        //    "ParentIdFk" 
        //};

        //IEnumerable<SyncGantt> SyncGanttList;
        //public string[] Searchfields = new string[] {
        //    "Id",
        //    "String",
        //    "Sdate",
        //    "Edate",
        //    "Duration",
        //    "Progress",
        //    "ParentId"
        //};

        IEnumerable<GanttTaskLoad> GanttTaskList;
        public string[] Searchfields = new string[] {
            "Id",
            "String",
            "Sdate",
            "Edate",
            "Duration",
            "Progress",
            "Parentid"
        };

        protected override void OnInitialized()
        {
            //GanttList = db.Set<LlamaLingo.Models.Gantt>().ToList();

            //SyncGanttList = BuildGanttTree();

            GanttTaskList = BuildGanttTree();
        }

        public List<GanttTaskLoad> BuildGanttTree()
        {
            //Create a list containing all of the data in the SyncGantt Table.
            List<GanttTaskLoad> allTasks = db.Set<GanttTaskLoad>().ToList();
            
            //Add a list of subtasks to each tasks.
            foreach (var task in allTasks)
            {
                task.SubTasks = allTasks.Where(s => s.Parentid == task.Id && s.Id != s.Parentid).ToList();
                
                 //Set random values for testing purposes.
                 // {
                    task.Duration = "1";
                    task.Progress = "1";
                 // }
            }

            //Create a list of only parent tasks.
            List<GanttTaskLoad> ParentTasks = allTasks.Where(s => s.Id == s.Parentid).ToList();

            return ParentTasks;
        }
    }
}