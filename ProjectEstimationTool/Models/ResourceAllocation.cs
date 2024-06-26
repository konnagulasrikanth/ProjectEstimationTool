﻿using System;
using System.Collections.Generic;

namespace ProjectEstimationTool.Models;

public partial class ResourceAllocation
{
    public int ResourceAllocationId { get; set; }

    public int ProjectId { get; set; }

    public int TimelineId { get; set; }

    public string Functionality { get; set; }

    public string Phase { get; set; }

    public int EffHrs { get; set; }

    public int ResReq { get; set; }

    public int Mm { get; set; }

    public int ResourceAllocated { get; set; }

    public int ResourcePending { get; set; }

    public virtual Project Project { get; set; }

    public virtual Timeline Timeline { get; set; }
}
