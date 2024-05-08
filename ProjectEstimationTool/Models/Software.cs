using System;
using System.Collections.Generic;

namespace ProjectEstimationTool.Models;

public partial class Software
{
    public int SoftwareId { get; set; }

    public int ProjectId { get; set; }

    public string SoftwareName { get; set; }

    public int MonthlyRate { get; set; }

    public virtual Project Project { get; set; }
}
