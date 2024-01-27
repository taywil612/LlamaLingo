using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LlamaLingo.Models;

public partial class DbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbContext()
    {
    }

    public DbContext(DbContextOptions<DbContext> options)
        : base(options)
    {
    }

	public virtual DbSet<ColorTest> ColorTests { get; set; }

	public virtual DbSet<Fragment> Fragments { get; set; }

	public virtual DbSet<Gantt> Gantts { get; set; }

	public virtual DbSet<GridDatum> GridData { get; set; }

	public virtual DbSet<GridRadial> GridRadials { get; set; }

	public virtual DbSet<GridTitle> GridTitles { get; set; }

	public virtual DbSet<LingoListNoun> LingoListNouns { get; set; }

	public virtual DbSet<Location> Locations { get; set; }

	public virtual DbSet<Logue> Logues { get; set; }

	public virtual DbSet<Noun> Nouns { get; set; }

	public virtual DbSet<Nova> Novas { get; set; }

	public virtual DbSet<Palette> Palettes { get; set; }

	public virtual DbSet<Person> People { get; set; }

	public virtual DbSet<Phase> Phases { get; set; }

	public virtual DbSet<Pod> Pods { get; set; }

	public virtual DbSet<Pype> Pypes { get; set; }

	public virtual DbSet<Task> Tasks { get; set; }

	public virtual DbSet<Verb> Verbs { get; set; }

	public virtual DbSet<ViewPodBase> ViewPodBases { get; set; }

	public virtual DbSet<Work> Works { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=llamalingo.database.windows.net;Database=LlamaLingoDB;User=LlamaLingoLogin;Password=UMDLlamaLingo4444");
    }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<ColorTest>(entity =>
		{
			entity.ToTable("ColorTest");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.BluStr).HasColumnName("bluStr");
			entity.Property(e => e.Color)
				.IsRequired()
				.HasMaxLength(10)
				.IsFixedLength()
				.HasColumnName("color");
			entity.Property(e => e.GrnStr).HasColumnName("grnStr");
			entity.Property(e => e.RedStr).HasColumnName("redStr");
		});

		modelBuilder.Entity<Fragment>(entity =>
		{
			entity.HasKey(e => e.FragId).HasName("PK_Fragment2");

			entity.ToTable("Fragment");

			entity.Property(e => e.FragId).HasColumnName("Frag_ID");
			entity.Property(e => e.FragByte).HasColumnName("Frag_byte");
			entity.Property(e => e.FragInt).HasColumnName("Frag_int");
			entity.Property(e => e.FragLabel)
				.IsRequired()
				.HasMaxLength(16)
				.HasDefaultValueSql("(N'string 16')")
				.IsFixedLength()
				.HasColumnName("Frag_label");
			entity.Property(e => e.FragReal).HasColumnName("Frag_real");
			entity.Property(e => e.FragSeq)
				.HasDefaultValueSql("((1))")
				.HasColumnName("Frag_seq");
			entity.Property(e => e.FragType)
				.IsRequired()
				.HasMaxLength(4)
				.HasDefaultValueSql("(N'frag')")
				.IsFixedLength()
				.HasColumnName("Frag_type");
			entity.Property(e => e.NounIdFk)
				.HasDefaultValueSql("((1))")
				.HasColumnName("NOUN_ID_FK");
		});

		modelBuilder.Entity<Gantt>(entity =>
		{
			entity
				.HasNoKey()
				.ToTable("Gantt");

			entity.Property(e => e.GanttDescription)
				.IsRequired()
				.HasMaxLength(255)
				.HasDefaultValueSql("('description of task')")
				.HasColumnName("Gantt_description");
			entity.Property(e => e.GanttDuration)
				.IsRequired()
				.HasMaxLength(64)
				.HasColumnName("Gantt_duration");
			entity.Property(e => e.GanttFinishDate)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("Gantt_finish_date");
			entity.Property(e => e.GanttId).HasColumnName("Gantt_ID");
			entity.Property(e => e.GanttLabel)
				.IsRequired()
				.HasMaxLength(16)
				.HasDefaultValueSql("('label16 task')")
				.IsFixedLength()
				.HasColumnName("Gantt_label");
			entity.Property(e => e.GanttProgress).HasColumnName("Gantt_progress");
			entity.Property(e => e.GanttStartDate)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("Gantt_start_date");
			entity.Property(e => e.GanttStatus)
				.IsRequired()
				.HasMaxLength(1)
				.HasDefaultValueSql("('A')")
				.IsFixedLength()
				.HasColumnName("Gantt_status");
			entity.Property(e => e.GanttType)
				.IsRequired()
				.HasMaxLength(4)
				.HasDefaultValueSql("(N'task')")
				.IsFixedLength()
				.HasColumnName("Gantt_type");
			entity.Property(e => e.ParentIdFk)
				.HasDefaultValueSql("((1))")
				.HasColumnName("Parent_ID_FK");
		});

		modelBuilder.Entity<GridDatum>(entity =>
		{
			entity.HasKey(e => new { e.GridTitleFk, e.GridDataLabel });

			entity.ToTable("Grid_Data");

			entity.Property(e => e.GridTitleFk)
				.HasDefaultValueSql("((2))")
				.HasColumnName("Grid_Title_FK");
			entity.Property(e => e.GridDataLabel)
				.HasMaxLength(16)
				.IsFixedLength()
				.HasColumnName("Grid_Data_label");
			entity.Property(e => e.GridDataDate)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("Grid_Data_date");
			entity.Property(e => e.GridDataRadial)
				.IsRequired()
				.HasMaxLength(16)
				.HasDefaultValueSql("(N'Radial Arm#')")
				.IsFixedLength()
				.HasColumnName("Grid_Data_radial");
			entity.Property(e => e.GridDataRadial1)
				.HasDefaultValueSql("((1))")
				.HasColumnName("Grid_Data_radial#");
			entity.Property(e => e.GridDataType)
				.IsRequired()
				.HasMaxLength(4)
				.HasDefaultValueSql("(N'skil')")
				.IsFixedLength()
				.HasColumnName("Grid_Data_type");
			entity.Property(e => e.GridDataValue)
				.HasDefaultValueSql("((4))")
				.HasColumnName("Grid_Data_value");
		});

		modelBuilder.Entity<GridRadial>(entity =>
		{
			entity
				.HasNoKey()
				.ToView("Grid_Radial");

			entity.Property(e => e.GridDataDate)
				.HasColumnType("datetime")
				.HasColumnName("Grid_Data_date");
			entity.Property(e => e.GridDataLabel)
				.IsRequired()
				.HasMaxLength(16)
				.IsFixedLength()
				.HasColumnName("Grid_Data_label");
			entity.Property(e => e.GridDataRadial)
				.IsRequired()
				.HasMaxLength(16)
				.IsFixedLength()
				.HasColumnName("Grid_Data_radial");
			entity.Property(e => e.GridDataRadial1).HasColumnName("Grid_Data_radial#");
			entity.Property(e => e.GridDataType)
				.IsRequired()
				.HasMaxLength(4)
				.IsFixedLength()
				.HasColumnName("Grid_Data_type");
			entity.Property(e => e.GridDataValue).HasColumnName("Grid_Data_value");
			entity.Property(e => e.GridTitleId).HasColumnName("Grid_Title_ID");
			entity.Property(e => e.GridTitleLabel64)
				.IsRequired()
				.HasMaxLength(64)
				.HasColumnName("Grid_Title_label64");
			entity.Property(e => e.PodIdFk).HasColumnName("POD_ID_FK");
			entity.Property(e => e.PodLabel)
				.IsRequired()
				.HasMaxLength(16)
				.HasColumnName("POD_label");
		});

		modelBuilder.Entity<GridTitle>(entity =>
		{
			entity.ToTable("Grid_Title");

			entity.Property(e => e.GridTitleId).HasColumnName("Grid_Title_ID");
			entity.Property(e => e.GridTitleLabel64)
				.IsRequired()
				.HasMaxLength(64)
				.HasDefaultValueSql("(N'POD data transfer grid title')")
				.HasColumnName("Grid_Title_label64");
			entity.Property(e => e.GridTitleStatus)
				.IsRequired()
				.HasMaxLength(1)
				.HasDefaultValueSql("(N'A')")
				.IsFixedLength()
				.HasColumnName("Grid_Title_status");
			entity.Property(e => e.GridTitleType)
				.IsRequired()
				.HasMaxLength(4)
				.HasDefaultValueSql("(N'grid')")
				.IsFixedLength()
				.HasColumnName("Grid_Title_type");
			entity.Property(e => e.PodIdFk)
				.HasDefaultValueSql("((4))")
				.HasColumnName("POD_ID_FK");
		});

		modelBuilder.Entity<LingoListNoun>(entity =>
		{
			entity
				.HasNoKey()
				.ToView("Lingo_List_Nouns");

			entity.Property(e => e.NounDescription)
				.IsRequired()
				.HasMaxLength(255)
				.HasColumnName("Noun_description");
			entity.Property(e => e.NounLabel)
				.IsRequired()
				.HasMaxLength(16)
				.IsFixedLength()
				.HasColumnName("Noun_label");
			entity.Property(e => e.NounType)
				.IsRequired()
				.HasMaxLength(4)
				.IsFixedLength()
				.HasColumnName("Noun_type");
			entity.Property(e => e.PodDescription)
				.IsRequired()
				.HasMaxLength(255)
				.HasColumnName("POD_description");
			entity.Property(e => e.PypeType)
				.IsRequired()
				.HasMaxLength(4)
				.IsFixedLength()
				.HasColumnName("Pype_type");
		});

		modelBuilder.Entity<Location>(entity =>
		{
			entity.ToTable("Location");

			entity.Property(e => e.LocationId).HasColumnName("Location_ID");
			entity.Property(e => e.LocationDescription)
				.IsRequired()
				.HasMaxLength(128)
				.HasDefaultValueSql("('location desc')")
				.HasColumnName("Location_description");
			entity.Property(e => e.LocationLabel)
				.IsRequired()
				.HasMaxLength(16)
				.HasDefaultValueSql("('label 16')")
				.HasColumnName("Location_label");
			entity.Property(e => e.LocationStatus)
				.IsRequired()
				.HasMaxLength(1)
				.HasDefaultValueSql("('A')")
				.IsFixedLength()
				.HasColumnName("Location_status");
			entity.Property(e => e.LocationType)
				.IsRequired()
				.HasMaxLength(4)
				.HasDefaultValueSql("(N'locs')")
				.IsFixedLength()
				.HasColumnName("Location_type");
			entity.Property(e => e.PersonFkAcad)
				.HasDefaultValueSql("((1))")
				.HasColumnName("Person_FK_acad");
			entity.Property(e => e.PersonFkAdmn)
				.HasDefaultValueSql("((1))")
				.HasColumnName("Person_FK_admn");
			entity.Property(e => e.PersonFkEngr)
				.HasDefaultValueSql("((1))")
				.HasColumnName("Person_FK_engr");
			entity.Property(e => e.PersonFkNnai)
				.HasDefaultValueSql("((1))")
				.HasColumnName("Person_FK_nnai");
			entity.Property(e => e.PersonFkXprt)
				.HasDefaultValueSql("((1))")
				.HasColumnName("Person_FK_xprt");
		});

		modelBuilder.Entity<Logue>(entity =>
		{
			entity.ToTable("Logue");

			entity.Property(e => e.LogueId).HasColumnName("Logue_ID");
			entity.Property(e => e.LogueEntryDate)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("Logue_entry_date");
			entity.Property(e => e.LogueLabel)
				.IsRequired()
				.HasMaxLength(16)
				.HasDefaultValueSql("('logue event ')")
				.IsFixedLength()
				.HasColumnName("Logue_label");
			entity.Property(e => e.LogueLevel)
				.HasDefaultValueSql("((1))")
				.HasColumnName("Logue_level");
			entity.Property(e => e.LogueStatus)
				.IsRequired()
				.HasMaxLength(1)
				.HasDefaultValueSql("('A')")
				.IsFixedLength()
				.HasColumnName("Logue_status");
			entity.Property(e => e.LogueType)
				.IsRequired()
				.HasMaxLength(4)
				.HasDefaultValueSql("(N'step')")
				.IsFixedLength()
				.HasColumnName("Logue_type");
			entity.Property(e => e.NounIdFk)
				.HasDefaultValueSql("((1))")
				.HasColumnName("NOUN_ID_FK");
			entity.Property(e => e.NovaIdFk)
				.HasDefaultValueSql("((1))")
				.HasColumnName("NOVA_ID_FK");
		});

		modelBuilder.Entity<Noun>(entity =>
		{
			entity.ToTable("Noun");

			entity.Property(e => e.NounId).HasColumnName("Noun_ID");
			entity.Property(e => e.NounDescription)
				.IsRequired()
				.HasMaxLength(255)
				.HasDefaultValueSql("(N'description of Noun')")
				.HasColumnName("Noun_description");
			entity.Property(e => e.NounLabel)
				.IsRequired()
				.HasMaxLength(16)
				.HasDefaultValueSql("(N'label 16')")
				.IsFixedLength()
				.HasColumnName("Noun_label");
			entity.Property(e => e.NounStatus)
				.IsRequired()
				.HasMaxLength(1)
				.HasDefaultValueSql("(N'A')")
				.IsFixedLength()
				.HasColumnName("Noun_status");
			entity.Property(e => e.NounType)
				.IsRequired()
				.HasMaxLength(4)
				.HasDefaultValueSql("(N'type')")
				.IsFixedLength()
				.HasColumnName("Noun_type");
			entity.Property(e => e.PodIdFk)
				.HasDefaultValueSql("((1))")
				.HasColumnName("POD_ID_FK");
			entity.Property(e => e.UrlIdPk)
				.HasDefaultValueSql("((1))")
				.HasColumnName("URL_ID_PK");
		});

		modelBuilder.Entity<Nova>(entity =>
		{
			entity.ToTable("NOVA");

			entity.Property(e => e.NovaId).HasColumnName("NOVA_ID");
			entity.Property(e => e.NovaAction)
				.HasDefaultValueSql("((1))")
				.HasColumnName("NOVA_action");
			entity.Property(e => e.NovaChannel)
				.HasDefaultValueSql("((1))")
				.HasColumnName("NOVA_channel");
			entity.Property(e => e.NovaDatetime)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("NOVA_datetime");
			entity.Property(e => e.NovaDescription)
				.IsRequired()
				.HasColumnName("NOVA_description");
			entity.Property(e => e.NovaObject)
				.HasDefaultValueSql("((1))")
				.HasColumnName("NOVA_object");
			entity.Property(e => e.NovaPrioriy)
				.HasDefaultValueSql("((4))")
				.HasColumnName("NOVA_prioriy");
			entity.Property(e => e.NovaStatus)
				.IsRequired()
				.HasMaxLength(1)
				.HasDefaultValueSql("(N'A')")
				.IsFixedLength()
				.HasColumnName("NOVA_status");
			entity.Property(e => e.NovaSubject)
				.HasDefaultValueSql("((1))")
				.HasColumnName("NOVA_subject");
			entity.Property(e => e.NovaType)
				.IsRequired()
				.HasMaxLength(4)
				.HasDefaultValueSql("(N'nova')")
				.IsFixedLength()
				.HasColumnName("NOVA_type");
			entity.Property(e => e.PersonIdFk)
				.HasDefaultValueSql("((1))")
				.HasColumnName("Person_ID_FK");
			entity.Property(e => e.PodIdFk)
				.HasDefaultValueSql("((1))")
				.HasColumnName("POD_ID_FK");
		});

		modelBuilder.Entity<Palette>(entity =>
		{
			entity.ToTable("Palette");

			entity.Property(e => e.PaletteId).HasColumnName("Palette_ID");
			entity.Property(e => e.NounIdFk)
				.HasDefaultValueSql("((1))")
				.HasColumnName("Noun_ID_FK");
			entity.Property(e => e.PaletteColor1)
				.HasDefaultValueSql("((255))")
				.HasColumnName("Palette_color_1");
			entity.Property(e => e.PaletteColor2)
				.HasDefaultValueSql("((255))")
				.HasColumnName("Palette_color_2");
			entity.Property(e => e.PaletteColor3)
				.HasDefaultValueSql("((255))")
				.HasColumnName("Palette_color_3");
			entity.Property(e => e.PaletteColor4)
				.HasDefaultValueSql("((255))")
				.HasColumnName("Palette_color_4");
			entity.Property(e => e.PaletteLabel)
				.IsRequired()
				.HasMaxLength(16)
				.HasDefaultValueSql("(N'label 16')")
				.IsFixedLength()
				.HasColumnName("Palette_label");
			entity.Property(e => e.PaletteSeq)
				.HasDefaultValueSql("((1))")
				.HasColumnName("Palette_seq");
			entity.Property(e => e.PaletteStatus)
				.IsRequired()
				.HasMaxLength(1)
				.HasDefaultValueSql("((3))")
				.IsFixedLength()
				.HasColumnName("Palette_status");
			entity.Property(e => e.PaletteType)
				.IsRequired()
				.HasMaxLength(4)
				.HasDefaultValueSql("(N'RGB')")
				.IsFixedLength()
				.HasColumnName("Palette_type");
		});

		modelBuilder.Entity<Person>(entity =>
		{
			entity.ToTable("Person");

			entity.Property(e => e.PersonId).HasColumnName("Person_ID");
			entity.Property(e => e.LocationIdFk)
				.HasDefaultValueSql("((1))")
				.HasColumnName("Location_ID_FK");
			entity.Property(e => e.PersonDatetime)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("Person_datetime");
			entity.Property(e => e.PersonFirst)
				.IsRequired()
				.HasMaxLength(32)
				.HasDefaultValueSql("(N'first')")
				.HasColumnName("Person_first");
			entity.Property(e => e.PersonLabel)
				.IsRequired()
				.HasMaxLength(16)
				.HasDefaultValueSql("(N'label 16')")
				.IsFixedLength()
				.HasColumnName("Person_label");
			entity.Property(e => e.PersonLast)
				.IsRequired()
				.HasMaxLength(32)
				.HasDefaultValueSql("(N'last')")
				.HasColumnName("Person_last");
			entity.Property(e => e.PersonRole)
				.IsRequired()
				.HasMaxLength(4)
				.HasDefaultValueSql("(N'role')")
				.IsFixedLength()
				.HasColumnName("Person_role");
			entity.Property(e => e.PersonStatus)
				.IsRequired()
				.HasMaxLength(1)
				.HasDefaultValueSql("('A')")
				.IsFixedLength()
				.HasColumnName("Person_status");
			entity.Property(e => e.PersonType)
				.IsRequired()
				.HasMaxLength(4)
				.HasDefaultValueSql("('hman')")
				.IsFixedLength()
				.HasColumnName("Person_type");
			entity.Property(e => e.PodIdFk)
				.HasDefaultValueSql("((1))")
				.HasColumnName("POD_ID_FK");
		});

		modelBuilder.Entity<Phase>(entity =>
		{
			entity.ToTable("Phase");

			entity.Property(e => e.PhaseId).HasColumnName("Phase_ID");
			entity.Property(e => e.NovaIdFk)
				.HasDefaultValueSql("((1))")
				.HasColumnName("NOVA_ID_FK");
			entity.Property(e => e.PersonIdFk)
				.HasDefaultValueSql("((1))")
				.HasColumnName("Person_ID_FK");
			entity.Property(e => e.PhaseDescription)
				.IsRequired()
				.HasMaxLength(255)
				.HasDefaultValueSql("('description of phase')")
				.HasColumnName("Phase_description");
			entity.Property(e => e.PhaseEntryDate)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("Phase_entry_date");
			entity.Property(e => e.PhaseFinishDate)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("Phase_finish_date");
			entity.Property(e => e.PhaseLabel)
				.IsRequired()
				.HasMaxLength(16)
				.HasDefaultValueSql("('label16 phase')")
				.IsFixedLength()
				.HasColumnName("Phase_label");
			entity.Property(e => e.PhaseStartDate)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("Phase_start_date");
			entity.Property(e => e.PhaseStatus)
				.IsRequired()
				.HasMaxLength(1)
				.HasDefaultValueSql("('A')")
				.IsFixedLength()
				.HasColumnName("Phase_status");
			entity.Property(e => e.PhaseType)
				.IsRequired()
				.HasMaxLength(4)
				.HasDefaultValueSql("(N'phas')")
				.IsFixedLength()
				.HasColumnName("Phase_type");
			entity.Property(e => e.ProjectIdFk)
				.HasDefaultValueSql("((1))")
				.HasColumnName("Project_ID_FK");
		});

		modelBuilder.Entity<Pod>(entity =>
		{
			entity.ToTable("POD");

			entity.Property(e => e.PodId).HasColumnName("POD_ID");
			entity.Property(e => e.LocationIdFk)
				.HasDefaultValueSql("((1))")
				.HasColumnName("Location_ID_FK");
			entity.Property(e => e.PersonIdFk)
				.HasDefaultValueSql("((1))")
				.HasColumnName("Person_ID_FK");
			entity.Property(e => e.PodChannel)
				.IsRequired()
				.HasMaxLength(4)
				.HasDefaultValueSql("(N'chan')")
				.IsFixedLength()
				.HasColumnName("POD_channel");
			entity.Property(e => e.PodDescription)
				.IsRequired()
				.HasMaxLength(255)
				.HasDefaultValueSql("(N'POD desc')")
				.HasColumnName("POD_description");
			entity.Property(e => e.PodLabel)
				.IsRequired()
				.HasMaxLength(16)
				.HasDefaultValueSql("(N'POD label')")
				.HasColumnName("POD_label");
			entity.Property(e => e.PodStatus)
				.IsRequired()
				.HasMaxLength(1)
				.HasDefaultValueSql("(N'A')")
				.IsFixedLength()
				.HasColumnName("POD_status");
			entity.Property(e => e.PodType)
				.IsRequired()
				.HasMaxLength(4)
				.HasDefaultValueSql("(N'pods')")
				.IsFixedLength()
				.HasColumnName("POD_type");
			entity.Property(e => e.PodUrlBase)
				.IsRequired()
				.HasMaxLength(128)
				.HasDefaultValueSql("(N'URL pointer to storage')")
				.HasColumnName("POD_URL_base");
		});

		modelBuilder.Entity<Pype>(entity =>
		{
			entity.HasKey(e => new { e.PypeId, e.PypeType });

			entity.ToTable("Pype");

			entity.Property(e => e.PypeId)
				.HasMaxLength(4)
				.HasDefaultValueSql("('NOVA')")
				.IsFixedLength()
				.HasColumnName("Pype_ID");
			entity.Property(e => e.PypeType)
				.HasMaxLength(4)
				.HasDefaultValueSql("('type')")
				.IsFixedLength()
				.HasColumnName("Pype_type");
			entity.Property(e => e.PodIdFk)
				.HasDefaultValueSql("((1))")
				.HasColumnName("POD_ID_FK");
			entity.Property(e => e.PypeDesc)
				.IsRequired()
				.HasMaxLength(64)
				.HasDefaultValueSql("('Domain Expert Definition')")
				.HasColumnName("Pype_desc");
			entity.Property(e => e.PypeLabel)
				.IsRequired()
				.HasMaxLength(16)
				.HasDefaultValueSql("('label 16')")
				.IsFixedLength()
				.HasColumnName("Pype_label");
			entity.Property(e => e.PypeLink)
				.IsRequired()
				.HasMaxLength(4)
				.HasDefaultValueSql("('stop')")
				.IsFixedLength()
				.HasColumnName("Pype_link");
			entity.Property(e => e.PypeStatus)
				.IsRequired()
				.HasMaxLength(1)
				.HasDefaultValueSql("('A')")
				.IsFixedLength()
				.HasColumnName("Pype_status");
		});

		modelBuilder.Entity<Task>(entity =>
		{
			entity.ToTable("Task");

			entity.Property(e => e.TaskId).HasColumnName("Task_ID");
			entity.Property(e => e.NovaIdFk)
				.HasDefaultValueSql("((1))")
				.HasColumnName("NOVA_ID_FK");
			entity.Property(e => e.PersonIdFk)
				.HasDefaultValueSql("((1))")
				.HasColumnName("Person_ID_FK");
			entity.Property(e => e.PhaseIdFk)
				.HasDefaultValueSql("((1))")
				.HasColumnName("Phase_ID_FK");
			entity.Property(e => e.TaskAfter)
				.HasDefaultValueSql("((1))")
				.HasColumnName("Task_after");
			entity.Property(e => e.TaskDescription)
				.IsRequired()
				.HasMaxLength(255)
				.HasDefaultValueSql("('description of task')")
				.HasColumnName("Task_description");
			entity.Property(e => e.TaskEntryDate)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("Task_entry_date");
			entity.Property(e => e.TaskFinishDate)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("Task_finish_date");
			entity.Property(e => e.TaskLabel)
				.IsRequired()
				.HasMaxLength(16)
				.HasDefaultValueSql("('label16 task')")
				.IsFixedLength()
				.HasColumnName("Task_label");
			entity.Property(e => e.TaskStartDate)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("Task_start_date");
			entity.Property(e => e.TaskStatus)
				.IsRequired()
				.HasMaxLength(1)
				.HasDefaultValueSql("('A')")
				.IsFixedLength()
				.HasColumnName("Task_status");
			entity.Property(e => e.TaskType)
				.IsRequired()
				.HasMaxLength(4)
				.HasDefaultValueSql("(N'task')")
				.IsFixedLength()
				.HasColumnName("Task_type");
		});

		modelBuilder.Entity<Verb>(entity =>
		{
			entity.ToTable("Verb");

			entity.Property(e => e.VerbId).HasColumnName("Verb_ID");
			entity.Property(e => e.PodIdFk)
				.HasDefaultValueSql("((1))")
				.HasColumnName("POD_ID_FK");
			entity.Property(e => e.UrlIdPk)
				.HasDefaultValueSql("((1))")
				.HasColumnName("URL_ID_PK");
			entity.Property(e => e.VerbDescription)
				.IsRequired()
				.HasMaxLength(255)
				.HasDefaultValueSql("(N'Description of Verb')")
				.HasColumnName("Verb_description");
			entity.Property(e => e.VerbLabel)
				.IsRequired()
				.HasMaxLength(16)
				.HasDefaultValueSql("(N'label 16')")
				.IsFixedLength()
				.HasColumnName("Verb_label");
			entity.Property(e => e.VerbStatus)
				.IsRequired()
				.HasMaxLength(1)
				.HasDefaultValueSql("(N'A')")
				.IsFixedLength()
				.HasColumnName("Verb_status");
			entity.Property(e => e.VerbType)
				.IsRequired()
				.HasMaxLength(4)
				.HasDefaultValueSql("(N'base')")
				.IsFixedLength()
				.HasColumnName("Verb_type");
		});

		modelBuilder.Entity<ViewPodBase>(entity =>
		{
			entity
				.HasNoKey()
				.ToView("View_POD_base");

			entity.Property(e => e.LocationDescription)
				.IsRequired()
				.HasMaxLength(128)
				.HasColumnName("Location_description");
			entity.Property(e => e.LocationIdFk).HasColumnName("Location_ID_FK");
			entity.Property(e => e.LocationLabel)
				.IsRequired()
				.HasMaxLength(16)
				.HasColumnName("Location_label");
			entity.Property(e => e.PersonFirst)
				.IsRequired()
				.HasMaxLength(32)
				.HasColumnName("Person_first");
			entity.Property(e => e.PersonLast)
				.IsRequired()
				.HasMaxLength(32)
				.HasColumnName("Person_last");
			entity.Property(e => e.PodChannel)
				.IsRequired()
				.HasMaxLength(4)
				.IsFixedLength()
				.HasColumnName("POD_channel");
			entity.Property(e => e.PodDescription)
				.IsRequired()
				.HasMaxLength(255)
				.HasColumnName("POD_description");
			entity.Property(e => e.PodId).HasColumnName("POD_ID");
			entity.Property(e => e.PodLabel)
				.IsRequired()
				.HasMaxLength(16)
				.HasColumnName("POD_label");
		});

		modelBuilder.Entity<Work>(entity =>
		{
			entity.ToTable("Work");

			entity.Property(e => e.WorkId).HasColumnName("Work_ID");
			entity.Property(e => e.NovaIdFk)
				.HasDefaultValueSql("((1))")
				.HasColumnName("NOVA_ID_FK");
			entity.Property(e => e.PersonIdFk)
				.HasDefaultValueSql("((1))")
				.HasColumnName("Person_ID_FK");
			entity.Property(e => e.TaskIdFk)
				.HasDefaultValueSql("((1))")
				.HasColumnName("Task_ID_FK");
			entity.Property(e => e.WorkDescription)
				.IsRequired()
				.HasMaxLength(255)
				.HasDefaultValueSql("('description of task')")
				.HasColumnName("Work_description");
			entity.Property(e => e.WorkEntryDate)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("Work_entry_date");
			entity.Property(e => e.WorkLabel)
				.IsRequired()
				.HasMaxLength(16)
				.HasDefaultValueSql("('label16 task')")
				.IsFixedLength()
				.HasColumnName("Work_label");
			entity.Property(e => e.WorkLevel)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("Work_level");
			entity.Property(e => e.WorkStartDate)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime")
				.HasColumnName("Work_start_date");
			entity.Property(e => e.WorkStatus)
				.IsRequired()
				.HasMaxLength(1)
				.HasDefaultValueSql("('A')")
				.IsFixedLength()
				.HasColumnName("Work_status");
			entity.Property(e => e.WorkType)
				.IsRequired()
				.HasMaxLength(4)
				.HasDefaultValueSql("(N'task')")
				.IsFixedLength()
				.HasColumnName("Work_type");
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
