using System;
using System.Collections.Generic;

namespace LlamaLingo.Models;

public partial class Nova
{
    public int NovaId { get; set; }

    public string NovaDescription { get; set; }

    public string NovaType { get; set; }

    public string NovaStatus { get; set; }

    public int NovaChannel { get; set; }

    public int NovaSubject { get; set; }

    public int NovaAction { get; set; }

    public int NovaObject { get; set; }

    public DateTime NovaDatetime { get; set; }

    public int PodIdFk { get; set; }

    public int PersonIdFk { get; set; }

    public short NovaPrioriy { get; set; }
}
