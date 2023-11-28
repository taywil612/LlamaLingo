using System;
using System.Collections.Generic;

namespace LlamaLingo.Models;

public partial class Phase
{
    public int PhaseId { get; set; }

    public string PhaseLabel { get; set; }

    public string PhaseType { get; set; }

    public string PhaseStatus { get; set; }

    public string PhaseDescription { get; set; }

    public DateTime PhaseStartDate { get; set; }

    public DateTime PhaseFinishDate { get; set; }

    public DateTime PhaseEntryDate { get; set; }

    public int ProjectIdFk { get; set; }

    public int NovaIdFk { get; set; }

    public int PersonIdFk { get; set; }
}
