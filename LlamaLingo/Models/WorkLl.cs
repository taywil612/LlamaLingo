using System;
using System.Collections.Generic;

namespace LlamaLingo.Models;

public partial class WorkLl
{
    public int WorkId { get; set; }

    public string WorkLabel { get; set; }

    public string WorkType { get; set; }

    public string WorkStatus { get; set; }

    public string WorkDescription { get; set; }

    public DateTime WorkEntryDate { get; set; }

    public DateTime WorkStartDate { get; set; }

    public DateTime WorkLevel { get; set; }

    public int TaskIdFk { get; set; }

    public int NovaIdFk { get; set; }

    public int PersonIdFk { get; set; }
}
