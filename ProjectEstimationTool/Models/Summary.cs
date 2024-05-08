using System;
using System.Collections.Generic;

namespace ProjectEstimationTool.Models;

public partial class Summary
{
    public int SummaryId { get; set; }

    public int ProjectId { get; set; }

    public double TravelBudget { get; set; }

    public double Contingency { get; set; }

    public virtual Project Project { get; set; }
}
