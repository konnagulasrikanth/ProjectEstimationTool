﻿using System;
using System.Collections.Generic;

namespace ProjectEstimationTool.Models;

public partial class ResourceCosting
{
    public int ResourceCostingId { get; set; }

    public int ProjectId { get; set; }

    public string Phase { get; set; }

    public int ResCount { get; set; }

    public string ResType { get; set; }

    public string Country { get; set; }

    public string RoleLevel { get; set; }

    public int HourlyRate { get; set; }

    public int MonthlyRate { get; set; }

    public int DurationMm { get; set; }

    public double Cost { get; set; }

    public int TimelineId { get; set; }

    public int ResourceId { get; set; }

    public virtual Project Project { get; set; }

    public virtual Resource Resource { get; set; }

    public virtual ICollection<SoftwareCosting> SoftwareCosting { get; set; } = new List<SoftwareCosting>();

    public virtual ICollection<SoftwareCostingTest> SoftwareCostingTest { get; set; } = new List<SoftwareCostingTest>();

    public virtual Timeline Timeline { get; set; }
}
