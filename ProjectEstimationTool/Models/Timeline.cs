using System;
using System.Collections.Generic;

namespace ProjectEstimationTool.Models;

public partial class Timeline
{
    public int TimelineId { get; set; }

    public int ProjectId { get; set; }

    public string Phase { get; set; }

    public int EffHrs { get; set; }

    public int ResReq { get; set; }

    public int Mm { get; set; }

    public int Lag { get; set; }

    public virtual Project Project { get; set; }

    public virtual ICollection<ResourceCosting> ResourceCosting { get; set; } = new List<ResourceCosting>();
}
