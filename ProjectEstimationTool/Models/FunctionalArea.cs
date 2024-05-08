using System;
using System.Collections.Generic;

namespace ProjectEstimationTool.Models;

public partial class FunctionalArea
{
    public int FunctionalAreaId { get; set; }

    public int ProjectId { get; set; }

    public string FunctionalAreaName { get; set; }

    public string FunctionalSubAreaName { get; set; }

    public virtual Project Project { get; set; }

    public virtual ICollection<ScopeAndEffort> ScopeAndEffort { get; set; } = new List<ScopeAndEffort>();
}
