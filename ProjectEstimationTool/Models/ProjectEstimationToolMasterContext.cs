﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjectEstimationTool.Models;

public partial class ProjectEstimationToolMasterContext : DbContext
{
    public ProjectEstimationToolMasterContext()
    {
    }

    public ProjectEstimationToolMasterContext(DbContextOptions<ProjectEstimationToolMasterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Country { get; set; }

    public virtual DbSet<DefaultEffortType> DefaultEffortType { get; set; }

    public virtual DbSet<DefaultFunctionalArea> DefaultFunctionalArea { get; set; }

    public virtual DbSet<DefaultFunctionalSubArea> DefaultFunctionalSubArea { get; set; }

    public virtual DbSet<DefaultProductivity> DefaultProductivity { get; set; }

    public virtual DbSet<DefaultResource> DefaultResource { get; set; }

    public virtual DbSet<DefaultSoftware> DefaultSoftware { get; set; }

    public virtual DbSet<Demodates> Demodates { get; set; }

    public virtual DbSet<EffortType> EffortType { get; set; }

    public virtual DbSet<FunctionalArea> FunctionalArea { get; set; }

    public virtual DbSet<FunctionalSubArea> FunctionalSubArea { get; set; }

    public virtual DbSet<Pdfversions> Pdfversions { get; set; }

    public virtual DbSet<Productivity> Productivity { get; set; }

    public virtual DbSet<Project> Project { get; set; }

    public virtual DbSet<Resource> Resource { get; set; }

    public virtual DbSet<ResourceCosting> ResourceCosting { get; set; }

    public virtual DbSet<ResourceLevel> ResourceLevel { get; set; }

    public virtual DbSet<ResourceTypes> ResourceTypes { get; set; }

    public virtual DbSet<ScopeAndEffort> ScopeAndEffort { get; set; }

    public virtual DbSet<Software> Software { get; set; }

    public virtual DbSet<SoftwareCosting> SoftwareCosting { get; set; }

    public virtual DbSet<SoftwareCostingTest> SoftwareCostingTest { get; set; }

    public virtual DbSet<Summary> Summary { get; set; }

    public virtual DbSet<Timeline> Timeline { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ICS-LT-64146D3\\SQLEXPRESS;Initial Catalog=ProjectEstimationToolMaster;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;Command Timeout=300");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK__Country__10D160BF760DCD79");

            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.CountryName)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

            entity.HasOne(d => d.Project).WithMany(p => p.Country)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK__Country__Project__0C1BC9F9");
        });

        modelBuilder.Entity<DefaultEffortType>(entity =>
        {
            entity.HasKey(e => e.EffortId).HasName("PK__DefaultE__F30B2296B89F7CBC");

            entity.HasIndex(e => e.EffortName, "UQ__DefaultE__0B575912FB834F9B").IsUnique();

            entity.Property(e => e.EffortId).HasColumnName("EffortID");
            entity.Property(e => e.Ba).HasColumnName("BA");
            entity.Property(e => e.EffortName)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Qa).HasColumnName("QA");
        });

        modelBuilder.Entity<DefaultFunctionalArea>(entity =>
        {
            entity.HasKey(e => e.FunctionalAreaid).HasName("PK__DefaultF__F17FAFE14BA2599F");

            entity.Property(e => e.FunctionalAreaName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FunctionalSubAreaName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DefaultFunctionalSubArea>(entity =>
        {
            entity.HasKey(e => e.FunctionalSubAreaid).HasName("PK__DefaultF__F572EE08C525A7B8");

            entity.HasIndex(e => e.FunctionalSubAreaName, "UQ__DefaultF__766A3F7DA4FD5940").IsUnique();

            entity.Property(e => e.FunctionalSubAreaName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DefaultProductivity>(entity =>
        {
            entity.HasKey(e => e.ProductivityId).HasName("PK__DefaultP__FA2DB72B4712F06E");

            entity.HasIndex(e => e.ProductivityName, "UQ__DefaultP__4F7B02CEBFAE8179").IsUnique();

            entity.Property(e => e.ProductivityId).HasColumnName("ProductivityID");
            entity.Property(e => e.ProductivityName)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DefaultResource>(entity =>
        {
            entity.HasKey(e => e.ResourceId).HasName("PK__DefaultR__4ED1814F5782D636");

            entity.Property(e => e.ResourceId).HasColumnName("ResourceID");
            entity.Property(e => e.CountryName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LevelName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TypeName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DefaultSoftware>(entity =>
        {
            entity.HasKey(e => e.SoftwareId).HasName("PK__DefaultS__25EDB8DCD3EE2A0A");

            entity.HasIndex(e => e.SoftwareName, "UQ__DefaultS__63C6CFD43C9DCBC8").IsUnique();

            entity.Property(e => e.SoftwareId).HasColumnName("SoftwareID");
            entity.Property(e => e.SoftwareName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Demodates>(entity =>
        {
            entity.HasKey(e => e.Demodateid).HasName("PK__Demodate__51233A0EC1756515");

            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

            entity.HasOne(d => d.Project).WithMany(p => p.Demodates)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK__Demodates__Proje__67DE6983");
        });

        modelBuilder.Entity<EffortType>(entity =>
        {
            entity.HasKey(e => e.EffortId).HasName("PK__EffortTy__F30B229663F845DD");

            entity.Property(e => e.EffortId).HasColumnName("EffortID");
            entity.Property(e => e.Ba).HasColumnName("BA");
            entity.Property(e => e.EffortName)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.Qa).HasColumnName("QA");

            entity.HasOne(d => d.Project).WithMany(p => p.EffortType)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK__EffortTyp__Proje__6ABAD62E");
        });

        modelBuilder.Entity<FunctionalArea>(entity =>
        {
            entity.HasKey(e => e.FunctionalAreaId).HasName("PK__Function__F17EABE9F462B442");

            entity.Property(e => e.FunctionalAreaId).HasColumnName("FunctionalAreaID");
            entity.Property(e => e.FunctionalAreaName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FunctionalSubAreaName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

            entity.HasOne(d => d.Project).WithMany(p => p.FunctionalArea)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK__Functiona__Proje__6D9742D9");
        });

        modelBuilder.Entity<FunctionalSubArea>(entity =>
        {
            entity.HasKey(e => e.FunctionalSubAreaId).HasName("PK__Function__F571EA00B6D9A5E5");

            entity.Property(e => e.FunctionalSubAreaId).HasColumnName("FunctionalSubAreaID");
            entity.Property(e => e.FunctionalSubAreaName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

            entity.HasOne(d => d.Project).WithMany(p => p.FunctionalSubArea)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK__Functiona__Proje__7073AF84");
        });

        modelBuilder.Entity<Pdfversions>(entity =>
        {
            entity.HasKey(e => e.Pdfid).HasName("PK__PDFVersi__F596046F3CCB18A2");

            entity.ToTable("PDFVersions");

            entity.Property(e => e.Pdfid).HasColumnName("pdfid");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.Version).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.Project).WithMany(p => p.Pdfversions)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK__PDFVersio__Proje__72E607DB");
        });

        modelBuilder.Entity<Productivity>(entity =>
        {
            entity.HasKey(e => e.ProductivityId).HasName("PK__Producti__FA2DB72BA6540018");

            entity.Property(e => e.ProductivityId).HasColumnName("ProductivityID");
            entity.Property(e => e.ProductivityName)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

            entity.HasOne(d => d.Project).WithMany(p => p.Productivity)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK__Productiv__Proje__73501C2F");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("PK__Project__761ABED023FCD8E0");

            entity.HasIndex(e => e.ProjectName, "UQ__Project__BCBE781CAD26F77D").IsUnique();

            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.ProjectName)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Resource>(entity =>
        {
            entity.HasKey(e => e.ResourceId).HasName("PK__Resource__4ED1814F8E2E4F65");

            entity.Property(e => e.ResourceId).HasColumnName("ResourceID");
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.CountryName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LevelId).HasColumnName("LevelID");
            entity.Property(e => e.LevelName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.ResourceTypeId).HasColumnName("ResourceTypeID");
            entity.Property(e => e.TypeName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Country).WithMany(p => p.Resource)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK__Resource__Countr__278EDA44");

            entity.HasOne(d => d.Level).WithMany(p => p.Resource)
                .HasForeignKey(d => d.LevelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Level_Data");

            entity.HasOne(d => d.Project).WithMany(p => p.Resource)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK__Resource__Projec__269AB60B");

            entity.HasOne(d => d.ResourceType).WithMany(p => p.Resource)
                .HasForeignKey(d => d.ResourceTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ResType_Data");
        });

        modelBuilder.Entity<ResourceCosting>(entity =>
        {
            entity.HasKey(e => e.ResourceCostingId).HasName("PK__Resource__ECBC631D2BDA21B8");

            entity.Property(e => e.ResourceCostingId).HasColumnName("ResourceCostingID");
            entity.Property(e => e.Country)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DurationMm).HasColumnName("DurationMM");
            entity.Property(e => e.Phase)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.ResType)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ResourceId).HasColumnName("ResourceID");
            entity.Property(e => e.RoleLevel)
                .IsRequired()
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.TimelineId).HasColumnName("TimelineID");

            entity.HasOne(d => d.Project).WithMany(p => p.ResourceCosting)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ResourceC__Proje__0EF836A4");

            entity.HasOne(d => d.Resource).WithMany(p => p.ResourceCosting)
                .HasForeignKey(d => d.ResourceId)
                .HasConstraintName("FK_Resource_Rate");

            entity.HasOne(d => d.Timeline).WithMany(p => p.ResourceCosting)
                .HasForeignKey(d => d.TimelineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ResourceC__Timel__7226EDCC");
        });

        modelBuilder.Entity<ResourceLevel>(entity =>
        {
            entity.HasKey(e => e.LevelId).HasName("PK__Resource__09F03C0604A1F7D4");

            entity.Property(e => e.LevelId).HasColumnName("LevelID");
            entity.Property(e => e.LevelName)
                .IsRequired()
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

            entity.HasOne(d => d.Project).WithMany(p => p.ResourceLevel)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK__ResourceL__Proje__7CD98669");
        });

        modelBuilder.Entity<ResourceTypes>(entity =>
        {
            entity.HasKey(e => e.ResourceTypeId).HasName("PK__Resource__31194FB987AB2908");

            entity.Property(e => e.ResourceTypeId).HasColumnName("ResourceTypeID");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.TypeName)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Project).WithMany(p => p.ResourceTypes)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK__ResourceT__Proje__7FB5F314");
        });

        modelBuilder.Entity<ScopeAndEffort>(entity =>
        {
            entity.HasKey(e => e.ScopeAndEffortId).HasName("PK__ScopeAnd__DDC0980BD79A59F4");

            entity.Property(e => e.ScopeAndEffortId).HasColumnName("ScopeAndEffortID");
            entity.Property(e => e.BaHrs).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.BafinalHrs)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("BAFinalHrs");
            entity.Property(e => e.BarefactorPercentage).HasColumnName("BARefactorPercentage");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DevFinalHrs).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DevHrs).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.EffortId).HasColumnName("EffortID");
            entity.Property(e => e.EffortName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FunctionalAreaId).HasColumnName("FunctionalAreaID");
            entity.Property(e => e.FunctionalAreaName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FunctionalSubAreaName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.QaHrs).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.QafinalHrs)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("QAFinalHrs");
            entity.Property(e => e.QarefactorPercentage).HasColumnName("QARefactorPercentage");

            entity.HasOne(d => d.EffortNavigation).WithMany(p => p.ScopeAndEffort)
                .HasForeignKey(d => d.EffortId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Effort_Data");

            entity.HasOne(d => d.FunctionalArea).WithMany(p => p.ScopeAndEffort)
                .HasForeignKey(d => d.FunctionalAreaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Func_Data");

            entity.HasOne(d => d.Project).WithMany(p => p.ScopeAndEffort)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK__ScopeAndE__Proje__00750D23");
        });

        modelBuilder.Entity<Software>(entity =>
        {
            entity.HasKey(e => e.SoftwareId).HasName("PK__Software__25EDB8DC131D5A30");

            entity.Property(e => e.SoftwareId).HasColumnName("SoftwareID");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.SoftwareName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Project).WithMany(p => p.Software)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK__Software__Projec__056ECC6A");
        });

        modelBuilder.Entity<SoftwareCosting>(entity =>
        {
            entity.HasKey(e => e.SoftwareCostId).HasName("PK__Software__E4084CCCF21BC77C");

            entity.Property(e => e.SoftwareCostId).HasColumnName("SoftwareCostID");
            entity.Property(e => e.DurationMm).HasColumnName("DurationMM");
            entity.Property(e => e.Phase)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.ResourceCostingId).HasColumnName("ResourceCostingID");
            entity.Property(e => e.SoftwareName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Project).WithMany(p => p.SoftwareCosting)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SoftwareC__Proje__5FD33367");

            entity.HasOne(d => d.ResourceCosting).WithMany(p => p.SoftwareCosting)
                .HasForeignKey(d => d.ResourceCostingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SoftwareC__Resou__61BB7BD9");
        });

        modelBuilder.Entity<SoftwareCostingTest>(entity =>
        {
            entity.HasKey(e => e.SoftwareCostId).HasName("PK__Software__E4084CCCCE494428");

            entity.Property(e => e.SoftwareCostId).HasColumnName("SoftwareCostID");
            entity.Property(e => e.Country)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DurationMm).HasColumnName("DurationMM");
            entity.Property(e => e.Phase)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.ResType)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ResourceCostingId).HasColumnName("ResourceCostingID");
            entity.Property(e => e.RoleLevel)
                .IsRequired()
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.SoftwareName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Project).WithMany(p => p.SoftwareCostingTest)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SoftwareC__Proje__05F8DC4F");

            entity.HasOne(d => d.ResourceCosting).WithMany(p => p.SoftwareCostingTest)
                .HasForeignKey(d => d.ResourceCostingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SoftwareC__Resou__06ED0088");
        });

        modelBuilder.Entity<Summary>(entity =>
        {
            entity.HasKey(e => e.SummaryId).HasName("PK__Summary__DAB10E0F68C7E24E");

            entity.Property(e => e.SummaryId).HasColumnName("SummaryID");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

            entity.HasOne(d => d.Project).WithMany(p => p.Summary)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK__Summary__Project__084B3915");
        });

        modelBuilder.Entity<Timeline>(entity =>
        {
            entity.HasKey(e => e.TimelineId).HasName("PK__Timeline__1DE4F0E5DF13572F");

            entity.Property(e => e.TimelineId).HasColumnName("TimelineID");
            entity.Property(e => e.Mm).HasColumnName("MM");
            entity.Property(e => e.Phase)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

            entity.HasOne(d => d.Project).WithMany(p => p.Timeline)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK__Timeline__Projec__3429BB53");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
