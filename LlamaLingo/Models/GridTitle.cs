using System;
using System.Collections.Generic;

namespace LlamaLingo.Models;

public partial class GridTitle
{
    public int GridTitleId { get; set; }

    public string GridTitleLabel64 { get; set; }

    public string GridTitleType { get; set; }

    public string GridTitleStatus { get; set; }

    public int PodIdFk { get; set; }
}
