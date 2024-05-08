using System;
using System.Collections.Generic;

namespace ProjectEstimationTool.Models;

public partial class Pdfversions
{
    public int Pdfid { get; set; }

    public int? ProjectId { get; set; }

    public decimal? Version { get; set; }

    public virtual Project Project { get; set; }
}
