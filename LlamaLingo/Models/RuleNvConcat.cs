using System;
using System.Collections.Generic;

namespace LlamaLingo.Models;

public partial class RuleNvConcat
{
    public int PodFk { get; set; }

    public string NounLabel { get; set; }

    public string VerbLabel { get; set; }

    public string ConNv { get; set; }

    public string Trim { get; set; }
}
