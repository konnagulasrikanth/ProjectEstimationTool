using System;
using System.Collections.Generic;

namespace ProjectEstimationTool.Models;

public partial class Project
{
    public int ProjectId { get; set; }

    public string ProjectName { get; set; }

    public virtual ICollection<Country> Country { get; set; } = new List<Country>();

    public virtual ICollection<Demodates> Demodates { get; set; } = new List<Demodates>();

    public virtual ICollection<EffortType> EffortType { get; set; } = new List<EffortType>();

    public virtual ICollection<FunctionalArea> FunctionalArea { get; set; } = new List<FunctionalArea>();

    public virtual ICollection<FunctionalSubArea> FunctionalSubArea { get; set; } = new List<FunctionalSubArea>();

    public virtual ICollection<Pdfversions> Pdfversions { get; set; } = new List<Pdfversions>();

    public virtual ICollection<Productivity> Productivity { get; set; } = new List<Productivity>();

    public virtual ICollection<Resource> Resource { get; set; } = new List<Resource>();

    public virtual ICollection<ResourceCosting> ResourceCosting { get; set; } = new List<ResourceCosting>();

    public virtual ICollection<ResourceLevel> ResourceLevel { get; set; } = new List<ResourceLevel>();

    public virtual ICollection<ResourceTypes> ResourceTypes { get; set; } = new List<ResourceTypes>();

    public virtual ICollection<ScopeAndEffort> ScopeAndEffort { get; set; } = new List<ScopeAndEffort>();

    public virtual ICollection<Software> Software { get; set; } = new List<Software>();

    public virtual ICollection<SoftwareCosting> SoftwareCosting { get; set; } = new List<SoftwareCosting>();

    public virtual ICollection<SoftwareCostingTest> SoftwareCostingTest { get; set; } = new List<SoftwareCostingTest>();

    public virtual ICollection<Summary> Summary { get; set; } = new List<Summary>();

    public virtual ICollection<Timeline> Timeline { get; set; } = new List<Timeline>();
}
