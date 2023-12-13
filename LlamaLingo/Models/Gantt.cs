using System;
using System.Collections.Generic;

namespace LlamaLingo.Models;

public partial class Gantt
{
    public string GanttLabel { get; set; }

    public string GanttType { get; set; }

    public string GanttStatus { get; set; }

    public string GanttDescription { get; set; }

    public DateTime GanttStartDate { get; set; }

    public DateTime GanttFinishDate { get; set; }

    public int GanttId { get; set; }

    public string GanttDuration { get; set; }

    public int GanttProgress { get; set; }

    public int ParentIdFk { get; set; }
}
