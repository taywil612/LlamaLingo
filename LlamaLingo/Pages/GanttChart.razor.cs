using System.Collections.Generic;
using System.Linq;

namespace LlamaLingo.Pages
{
	public partial class GanttChart
    {
        IEnumerable<LlamaLingo.Models.Gantt> GanttList;

        protected override void OnInitialized()
        {
            GanttList = db.Set<LlamaLingo.Models.Gantt>().ToList();
        }

        public string[] Searchfields = new string[] { 
            "GanttId", 
            "GanttLabel", 
            "GanttStartDate", 
            "GanttFinishDate", 
            "GanttDuration", 
            "GanttProgress", 
            "ParentIdFk" 
        };

    }
}