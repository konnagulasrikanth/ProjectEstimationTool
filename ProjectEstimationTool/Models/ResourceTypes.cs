﻿using System;
using System.Collections.Generic;

namespace ProjectEstimationTool.Models;

public partial class ResourceTypes
{
    public int ResourceTypeId { get; set; }

    public int ProjectId { get; set; }

    public string TypeName { get; set; }

    public virtual Project Project { get; set; }

    public virtual ICollection<Resource> Resource { get; set; } = new List<Resource>();
}
