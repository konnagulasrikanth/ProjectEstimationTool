using System;
using System.Collections.Generic;

namespace ProjectEstimationTool.Models;

public partial class DefaultEffortType
{
    public int EffortId { get; set; }

    public string EffortName { get; set; }

    public int ActualEffort { get; set; }

    public int Ba { get; set; }

    public int Dev { get; set; }

    public int Qa { get; set; }
}
