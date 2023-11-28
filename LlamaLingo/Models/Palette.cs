using System;
using System.Collections.Generic;

namespace LlamaLingo.Models;

public partial class Palette
{
    public int PaletteId { get; set; }

    public string PaletteLabel { get; set; }

    public string PaletteType { get; set; }

    public string PaletteStatus { get; set; }

    public short PaletteSeq { get; set; }

    public short PaletteColor1 { get; set; }

    public short PaletteColor2 { get; set; }

    public short PaletteColor3 { get; set; }

    public short PaletteColor4 { get; set; }

    public int NounIdFk { get; set; }
}
