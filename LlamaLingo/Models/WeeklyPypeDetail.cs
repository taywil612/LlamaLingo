using System;
using System.Collections.Generic;

namespace LlamaLingo.Models;

public partial class WeeklyPypeDetail
{
    public int Project { get; set; }

    public int WeekId { get; set; }

    public int? PersonId { get; set; }

    public int Noun { get; set; }

    public string PersonLabel { get; set; }

    public int ElementId { get; set; }

    public string NounLabel { get; set; }

    public string ElementLabel { get; set; }

    public short Quantity { get; set; }

    public int ElementInt { get; set; }

    public int? ChartData1 { get; set; }

    public float Scaling { get; set; }

    public float? ChartData2 { get; set; }

    public string NounType { get; set; }

    public string ElementType { get; set; }

    public short Grp { get; set; }

    public int? _8wkIntAve { get; set; }
}
