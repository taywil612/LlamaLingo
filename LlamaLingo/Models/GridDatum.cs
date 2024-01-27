using System;
using System.Collections.Generic;

namespace LlamaLingo.Models;

public partial class GridDatum
{
    public int GridTitleFk { get; set; }

    public string GridDataLabel { get; set; }

    public DateTime GridDataDate { get; set; }

    public string GridDataType { get; set; }

    public int GridDataValue { get; set; }

    public string GridDataRadial { get; set; }

    public short GridDataRadial1 { get; set; }
}
