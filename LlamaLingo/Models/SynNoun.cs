using System;
using System.Collections.Generic;

namespace LlamaLingo.Models;

public partial class SynNoun
{
    public string SynNId { get; set; }

    public string SynNReplace { get; set; }

    public short SynNSet { get; set; }

    public int PodIdFk { get; set; }
}
