﻿using System;
using System.Collections.Generic;

namespace ProjectEstimationTool.Models;

public partial class DefaultResource
{
    public int ResourceId { get; set; }

    public string CountryName { get; set; }

    public string TypeName { get; set; }

    public string LevelName { get; set; }

    public int HourlyRate { get; set; }
}
