using System;
using System.Collections.Generic;

namespace ProjectEstimationTool.Models;

public partial class EffortType
{
    public int EffortId { get; set; }

    public int ProjectId { get; set; }

    public string EffortName { get; set; }

    public int ActualEffort { get; set; }

    public int Ba { get; set; }

    public int Dev { get; set; }

    public int Qa { get; set; }

    public virtual Project Project { get; set; }

    public virtual ICollection<ScopeAndEffort> ScopeAndEffort { get; set; } = new List<ScopeAndEffort>();
}
