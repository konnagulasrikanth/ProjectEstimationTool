﻿using System;
using System.Collections.Generic;

namespace ProjectEstimationTool.Models;

public partial class Demodates
{
    public int Demodateid { get; set; }

    public int ProjectId { get; set; }

    public int Demodate1 { get; set; }

    public int Demodate2 { get; set; }

    public virtual Project Project { get; set; }
}
