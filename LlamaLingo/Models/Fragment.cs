using System;
using System.Collections.Generic;

namespace LlamaLingo.Models;

public partial class Fragment
{
    public int FragId { get; set; }

    public string FragLabel { get; set; }

    public string FragType { get; set; }

    public short FragSeq { get; set; }

    public short FragByte { get; set; }

    public int FragInt { get; set; }

    public float FragReal { get; set; }

    public int NounIdFk { get; set; }
}
