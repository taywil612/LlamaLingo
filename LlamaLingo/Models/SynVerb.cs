using System;
using System.Collections.Generic;

namespace LlamaLingo.Models;

public partial class SynVerb
{
    public string SynVId { get; set; }

    public string SynVReplace { get; set; }

    public short SynVSet { get; set; }

    public int PodIdFk { get; set; }
}
