using System;
using System.Collections.Generic;

namespace LlamaLingo.Models;

public partial class NetCommand
{
    public int PersonIdFk { get; set; }

    public DateTime NetDateTime { get; set; }

    public string NetCommand1 { get; set; }

    public string NetLabel16 { get; set; }

    public string NetType { get; set; }

    public string NetStatus { get; set; }

    public DateTime NetLog { get; set; }

    public byte NetPriority { get; set; }
}
