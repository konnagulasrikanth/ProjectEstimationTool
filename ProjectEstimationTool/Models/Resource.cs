﻿using System;
using System.Collections.Generic;

namespace ProjectEstimationTool.Models;

public partial class Resource
{
    public int ResourceId { get; set; }

    public int? ProjectId { get; set; }

    public int? CountryId { get; set; }

    public string CountryName { get; set; }

    public string TypeName { get; set; }

    public string LevelName { get; set; }

    public int HourlyRate { get; set; }

    public int ResourceTypeId { get; set; }

    public int LevelId { get; set; }

    public virtual Country Country { get; set; }

    public virtual ResourceLevel Level { get; set; }

    public virtual Project Project { get; set; }

    public virtual ICollection<ResourceCosting> ResourceCosting { get; set; } = new List<ResourceCosting>();

    public virtual ResourceTypes ResourceType { get; set; }
}
