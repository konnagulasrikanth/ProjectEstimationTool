using System;
using System.Collections.Generic;

namespace ProjectEstimationTool.Models;

public partial class DefaultProductivity
{
    public int ProductivityId { get; set; }

    public string ProductivityName { get; set; }

    public int Hours { get; set; }
}
