using System;
using System.Collections.Generic;

namespace LlamaLingo.Models;

public partial class PodGanttDetail
{
    public int Id { get; set; }

    public string String { get; set; }

    public DateTime Sdate { get; set; }

    public DateTime Edate { get; set; }

    public string Progress { get; set; }

    public string TaskType { get; set; }

    public string TaskStatus { get; set; }

    public string TaskDescription { get; set; }

    public DateTime TaskEntryDate { get; set; }

    public int TaskAfter { get; set; }

    public int PhaseIdFk { get; set; }

    public int NovaIdFk { get; set; }

    public int PersonIdFk { get; set; }
}
