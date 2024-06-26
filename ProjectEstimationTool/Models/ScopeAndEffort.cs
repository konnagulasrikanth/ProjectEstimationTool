﻿using System;
using System.Collections.Generic;

namespace ProjectEstimationTool.Models;

public partial class ScopeAndEffort
{
    public int ScopeAndEffortId { get; set; }

    public int ProjectId { get; set; }

    public string FunctionalAreaName { get; set; }

    public string FunctionalSubAreaName { get; set; }

    public string EffortName { get; set; }

    public int NumberOfOperations { get; set; }

    public int Effort { get; set; }

    public decimal BaHrs { get; set; }

    public int BarefactorPercentage { get; set; }

    public decimal BafinalHrs { get; set; }

    public decimal DevHrs { get; set; }

    public int DevRefactorPercentage { get; set; }

    public decimal DevFinalHrs { get; set; }

    public decimal QaHrs { get; set; }

    public int QarefactorPercentage { get; set; }

    public decimal QafinalHrs { get; set; }

    public string Description { get; set; }

    public int EffortId { get; set; }

    public int FunctionalAreaId { get; set; }

    public virtual EffortType EffortNavigation { get; set; }

    public virtual FunctionalArea FunctionalArea { get; set; }

    public virtual Project Project { get; set; }
}
