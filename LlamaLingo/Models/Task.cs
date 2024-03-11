using System;
using System.Collections.Generic;

namespace LlamaLingo.Models;

public partial class Task
{
    public int TaskId { get; set; }

    public string TaskLabel { get; set; }

    public string TaskType { get; set; }

    public string TaskStatus { get; set; }

    public string TaskDescription { get; set; }

    public DateTime TaskStartDate { get; set; }

    public DateTime TaskFinishDate { get; set; }

    public DateTime TaskEntryDate { get; set; }

    public int TaskAfter { get; set; }

    public int PhaseIdFk { get; set; }

    public int NovaIdFk { get; set; }

    public int PersonIdFk { get; set; }
}
