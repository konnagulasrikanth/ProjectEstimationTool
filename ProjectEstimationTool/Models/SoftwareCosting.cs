using System;
using System.Collections.Generic;

namespace ProjectEstimationTool.Models;

public partial class SoftwareCosting
{
    public int SoftwareCostId { get; set; }

    public int ProjectId { get; set; }

    public int ResourceCostingId { get; set; }

    public string Phase { get; set; }

    public int ResCount { get; set; }

    public string SoftwareName { get; set; }

    public int? SoftwareCost { get; set; }

    public int? DurationMm { get; set; }

    public virtual Project Project { get; set; }

    public virtual ResourceCosting ResourceCosting { get; set; }
}
