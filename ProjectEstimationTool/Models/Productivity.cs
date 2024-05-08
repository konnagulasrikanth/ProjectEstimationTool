using System;
using System.Collections.Generic;

namespace ProjectEstimationTool.Models;

public partial class Productivity
{
    public int ProductivityId { get; set; }

    public int ProjectId { get; set; }

    public string ProductivityName { get; set; }

    public int Hours { get; set; }

    public virtual Project Project { get; set; }
}
