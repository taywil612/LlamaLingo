using LlamaLingo.Models;
using Microsoft.IdentityModel.Tokens;
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

        IEnumerable<LlamaLingo.Models.SyncGantt> SyncGanttList;
        public string[] Searchfields = new string[] {
            "Id",
            "String",
            "Sdate",
            "Edate",
            "Duration",
            "Progress",
            "ParentId"
        };
        protected override void OnInitialized()
        {
            //GanttList = db.Set<LlamaLingo.Models.Gantt>().ToList();

            SyncGanttList = BuildGanttTree();           
        }

        public List<SyncGantt> BuildGanttTree()
        {
            //Create a list containing all of the data in the SyncGantt Table.
            List<SyncGantt> allTasks = db.Set<SyncGantt>().ToList();

            //Add a list of subtasks to each tasks.
            foreach(var task in allTasks)
            {
                task.SubTasks = allTasks.Where(s => s.ParentId == task.Id).ToList();
            }

            //Create a list of only parent tasks.
            List<SyncGantt> ParentTasks = allTasks.Where(s => s.ParentId == null).ToList();

            return ParentTasks;
        }
    }
}