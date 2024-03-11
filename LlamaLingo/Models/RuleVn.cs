using System;
using System.Collections.Generic;

namespace LlamaLingo.Models;

public partial class RuleVn
{
    public int PodFk { get; set; }

    public int VerbFk { get; set; }

    public int NounFk { get; set; }
}
