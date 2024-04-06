using System;
using System.Collections.Generic;

namespace LlamaLingo.Models;

public partial class DupHerc
{
    public int TaskId { get; set; }

    public string TaskLabel32 { get; set; }

    public string TaskType { get; set; }

    public string TaskStatus { get; set; }

    public short TaskLevel { get; set; }

    public string TaskDescription { get; set; }

    public short TaskDuration { get; set; }

    public DateTime TaskStartDate { get; set; }

    public DateTime TaskFinishDate { get; set; }

    public DateTime TaskEntryDate { get; set; }

    public int TaskPrevious { get; set; }

    public int PersonIdFk { get; set; }

    public int NovaIdFk { get; set; }

    public int NounIdFk { get; set; }

    public int PodIdFk { get; set; }

    public short TaskSeq { get; set; }

    public int TaskParent { get; set; }
}
