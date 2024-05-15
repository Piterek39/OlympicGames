using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Core.Models;

namespace Infrastructure.Db;

public partial class OlympicGamesDbContext : DbContext
{
    public OlympicGamesDbContext()
    {
    }

    public OlympicGamesDbContext(DbContextOptions<OlympicGamesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<CompetitorEvent> CompetitorEvents { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<GamesCity> GamesCities { get; set; }

    public virtual DbSet<GamesCompetitor> GamesCompetitors { get; set; }

    public virtual DbSet<Medal> Medals { get; set; }

    public virtual DbSet<NocRegion> NocRegions { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<PersonRegion> PersonRegions { get; set; }

    public virtual DbSet<Sport> Sports { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=olympics;TrustServerCertificate=True;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__city__3213E83F6A6B0D91");

            entity.ToTable("city");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CityName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("city_name");
        });

        modelBuilder.Entity<CompetitorEvent>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("competitor_event");

            entity.Property(e => e.CompetitorId).HasColumnName("competitor_id");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.MedalId).HasColumnName("medal_id");

            entity.HasOne(d => d.Competitor).WithMany()
                .HasForeignKey(d => d.CompetitorId)
                .HasConstraintName("fk_ce_com");

            entity.HasOne(d => d.Event).WithMany()
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("fk_ce_ev");

            entity.HasOne(d => d.Medal).WithMany()
                .HasForeignKey(d => d.MedalId)
                .HasConstraintName("fk_ce_med");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__event__3213E83F4E0F25C5");

            entity.ToTable("event");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.EventName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("event_name");
            entity.Property(e => e.SportId).HasColumnName("sport_id");

            entity.HasOne(d => d.Sport).WithMany(p => p.Events)
                .HasForeignKey(d => d.SportId)
                .HasConstraintName("fk_ev_sp");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__games__3213E83F15CE5477");

            entity.ToTable("games");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.GamesName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("games_name");
            entity.Property(e => e.GamesYear).HasColumnName("games_year");
            entity.Property(e => e.Season)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("season");
        });

        modelBuilder.Entity<GamesCity>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("games_city");

            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.GamesId).HasColumnName("games_id");

            entity.HasOne(d => d.City).WithMany()
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("fk_gci_city");

            entity.HasOne(d => d.Games).WithMany()
                .HasForeignKey(d => d.GamesId)
                .HasConstraintName("fk_gci_gam");
        });

        modelBuilder.Entity<GamesCompetitor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__games_co__3213E83F60C2888A");

            entity.ToTable("games_competitor");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.GamesId).HasColumnName("games_id");
            entity.Property(e => e.PersonId).HasColumnName("person_id");

            entity.HasOne(d => d.Games).WithMany(p => p.GamesCompetitors)
                .HasForeignKey(d => d.GamesId)
                .HasConstraintName("fk_gc_gam");

            entity.HasOne(d => d.Person).WithMany(p => p.GamesCompetitors)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("fk_gc_per");
        });

        modelBuilder.Entity<Medal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__medal__3213E83F8DDD07AC");

            entity.ToTable("medal");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.MedalName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("medal_name");
        });

        modelBuilder.Entity<NocRegion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__noc_regi__3213E83F69C441D7");

            entity.ToTable("noc_region");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Noc)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("noc");
            entity.Property(e => e.RegionName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("region_name");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__person__3213E83FB1E5042F");

            entity.ToTable("person");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.FullName)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("full_name");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Height).HasColumnName("height");
            entity.Property(e => e.Weight).HasColumnName("weight");
        });

        modelBuilder.Entity<PersonRegion>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("person_region");

            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.RegionId).HasColumnName("region_id");

            entity.HasOne(d => d.Person).WithMany()
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("fk_per_per");

            entity.HasOne(d => d.Region).WithMany()
                .HasForeignKey(d => d.RegionId)
                .HasConstraintName("fk_per_reg");
        });

        modelBuilder.Entity<Sport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__sport__3213E83FFB827D10");

            entity.ToTable("sport");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.SportName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("sport_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
