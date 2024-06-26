﻿using System;
using System.Collections.Generic;

namespace LlamaLingo.Models;

public partial class SyncGantt
{
    public int? Id { get; set; }

    public string String { get; set; }

    public DateTime? Sdate { get; set; }

    public DateTime? Edate { get; set; }

    public string Progress { get; set; }

    public int? ParentId { get; set; }

    public string Duration { get; set; }

    public string ProjectName { get; set; }

    public DateTime? BaselineStartDate { get; set; }

    public DateTime? BaselineEndDate { get; set; }

    public string Predecessor { get; set; }

    public string Notes { get; set; }

    public string TaskType { get; set; }

    public string ProjectId { get; set; }

    public string IsExpand { get; set; }
}
