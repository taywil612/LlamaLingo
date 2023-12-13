using System;
using System.Collections.Generic;

namespace LlamaLingo.Models;

public partial class Logue
{
    public int LogueId { get; set; }

    public string LogueLabel { get; set; }

    public string LogueType { get; set; }

    public string LogueStatus { get; set; }

    public DateTime LogueEntryDate { get; set; }

    public short LogueLevel { get; set; }

    public int NounIdFk { get; set; }

    public int NovaIdFk { get; set; }
}
