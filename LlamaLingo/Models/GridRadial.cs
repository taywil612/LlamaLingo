using System;
using System.Collections.Generic;

namespace LlamaLingo.Models;

public partial class GridRadial
{
    public string PodLabel { get; set; }

    public int PodIdFk { get; set; }

    public int GridTitleId { get; set; }

    public string GridTitleLabel64 { get; set; }

    public string GridDataLabel { get; set; }

    public DateTime GridDataDate { get; set; }

    public string GridDataType { get; set; }

    public int GridDataValue { get; set; }

    public string GridDataRadial { get; set; }

    public short GridDataRadial1 { get; set; }
}
