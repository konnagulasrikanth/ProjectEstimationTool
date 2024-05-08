using System;
using System.Collections.Generic;

namespace ProjectEstimationTool.Models;

public partial class FunctionalSubArea
{
    public int FunctionalSubAreaId { get; set; }

    public int ProjectId { get; set; }

    public string FunctionalSubAreaName { get; set; }

    public virtual Project Project { get; set; }
}
