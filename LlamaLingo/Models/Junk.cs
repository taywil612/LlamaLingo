using System;
using System.Collections.Generic;

namespace LlamaLingo.Models;

public partial class Junk
{
    public int PodIdFk { get; set; }

    public int PodId { get; set; }

    public string PodLabel { get; set; }

    public string PypeType { get; set; }

    public string PypeLabel { get; set; }
}
