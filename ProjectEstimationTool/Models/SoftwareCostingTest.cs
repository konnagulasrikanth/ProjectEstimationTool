using System;
using System.Collections.Generic;

namespace ProjectEstimationTool.Models;

public partial class SoftwareCostingTest
{
    public int SoftwareCostId { get; set; }

    public int ProjectId { get; set; }

    public int ResourceCostingId { get; set; }

    public string Phase { get; set; }

    public int ResCount { get; set; }

    public string ResType { get; set; }

    public string Country { get; set; }

    public string RoleLevel { get; set; }

    public string SoftwareName { get; set; }

    public int? SoftwareCost { get; set; }

    public int? DurationMm { get; set; }

    public virtual Project Project { get; set; }

    public virtual ResourceCosting ResourceCosting { get; set; }
}
