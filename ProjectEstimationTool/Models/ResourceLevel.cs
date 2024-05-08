using System;
using System.Collections.Generic;

namespace ProjectEstimationTool.Models;

public partial class ResourceLevel
{
    public int LevelId { get; set; }

    public int ProjectId { get; set; }

    public string LevelName { get; set; }

    public virtual Project Project { get; set; }

    public virtual ICollection<Resource> Resource { get; set; } = new List<Resource>();
}
