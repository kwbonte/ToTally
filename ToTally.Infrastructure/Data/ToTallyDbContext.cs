using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToTally.Domain.Common;
using ToTally.Domain.Conferences;
using ToTally.Domain.Divisions;
using ToTally.Domain.Leagues;
using ToTally.Domain.Teams;
using ToTally.Domain.Venues;

namespace ToTally.Infrastructure.Data;

public class ToTallyDbContext : DbContext
{
    public ToTallyDbContext(DbContextOptions<ToTallyDbContext> options)
        : base(options)
    {
    }

    public DbSet<League> Leagues => Set<League>();

    public DbSet<Venue> Venues => Set<Venue>();

    public DbSet<Conference> Conferences => Set<Conference>();

    public DbSet<Division> Divisions => Set<Division>();
    public DbSet<Team> Teams => Set<Team>();
    public override int SaveChanges()
    {
        ApplyEntityBaseRules();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ApplyEntityBaseRules();
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<League>(entity =>
        {
            entity.ToTable("leagues");

            entity.HasKey(league => league.Id);

            entity.Property(league => league.Id)
                .HasColumnName("id");

            entity.Property(league => league.Name)
                .HasColumnName("name")
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(league => league.Abbreviation)
                .HasColumnName("abbreviation")
                .HasMaxLength(10)
                .IsRequired();

            entity.HasIndex(league => league.Abbreviation)
                .IsUnique();

            entity.Property(league => league.Sport)
                .HasColumnName("sport")
                .HasMaxLength(50)
                .IsRequired();

            ConfigureEntityBase(entity);
        });

        modelBuilder.Entity<Conference>(entity =>
        {
            entity.ToTable("conferences");

            entity.HasKey(conference => conference.Id);

            entity.Property(conference => conference.Id)
                .HasColumnName("id");

            entity.Property(conference => conference.LeagueId)
                .HasColumnName("league_id")
                .IsRequired();

            entity.Property(conference => conference.Name)
                .HasColumnName("name")
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(conference => conference.Abbreviation)
                .HasColumnName("abbreviation")
                .HasMaxLength(10)
                .IsRequired();

            entity.HasOne(conference => conference.League)
                .WithMany(league => league.Conferences)
                .HasForeignKey(conference => conference.LeagueId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(conference => new
            {
                conference.LeagueId,
                conference.Name
            }).IsUnique();

            entity.HasIndex(conference => new
            {
                conference.LeagueId,
                conference.Abbreviation
            }).IsUnique();

            ConfigureEntityBase(entity);
        });

        modelBuilder.Entity<Division>(entity =>
        {
            entity.ToTable("divisions");

            entity.HasKey(division => division.Id);

            entity.Property(division => division.Id)
                .HasColumnName("id");

            entity.Property(division => division.ConferenceId)
                .HasColumnName("conference_id")
                .IsRequired();

            entity.Property(division => division.Name)
                .HasColumnName("name")
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(division => division.Abbreviation)
                .HasColumnName("abbreviation")
                .HasMaxLength(10)
                .IsRequired();

            entity.HasOne(division => division.Conference)
                .WithMany(conference => conference.Divisions)
                .HasForeignKey(division => division.ConferenceId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(division => new
            {
                division.ConferenceId,
                division.Name
            }).IsUnique();

            entity.HasIndex(division => new
            {
                division.ConferenceId,
                division.Abbreviation
            }).IsUnique();

            ConfigureEntityBase(entity);
        });

        modelBuilder.Entity<Venue>(entity =>
        {
            entity.ToTable("venues");

            entity.HasKey(venue => venue.Id);

            entity.Property(venue => venue.Id)
                .HasColumnName("id");

            entity.Property(venue => venue.Name)
                .HasColumnName("name")
                .HasMaxLength(150)
                .IsRequired();

            entity.Property(venue => venue.City)
                .HasColumnName("city")
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(venue => venue.StateOrCountry)
                .HasColumnName("state_or_country")
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(venue => venue.Latitude)
                .HasColumnName("latitude")
                .HasPrecision(9, 6);

            entity.Property(venue => venue.Longitude)
                .HasColumnName("longitude")
                .HasPrecision(9, 6);

            entity.Property(venue => venue.IsDome)
                .HasColumnName("is_dome")
                .IsRequired();

            entity.Property(venue => venue.IsNeutralSiteCapable)
                .HasColumnName("is_neutral_site_capable")
                .IsRequired();

            entity.HasIndex(venue => venue.Name);

            ConfigureEntityBase(entity);
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.ToTable("teams");

            entity.HasKey(team => team.Id);

            entity.Property(team => team.Id)
                .HasColumnName("id");

            entity.Property(team => team.DivisionId)
                .HasColumnName("division_id")
                .IsRequired();

            entity.Property(team => team.VenueId)
                .HasColumnName("venue_id")
                .IsRequired();

            entity.Property(team => team.Name)
                .HasColumnName("name")
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(team => team.Abbreviation)
                .HasColumnName("abbreviation")
                .HasMaxLength(10)
                .IsRequired();

            entity.Property(team => team.City)
                .HasColumnName("city")
                .HasMaxLength(100)
                .IsRequired();

            entity.HasOne(team => team.Division)
                .WithMany(division => division.Teams)
                .HasForeignKey(team => team.DivisionId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(team => team.Venue)
                .WithMany()
                .HasForeignKey(team => team.VenueId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(team => team.Abbreviation)
                .IsUnique();

            entity.HasIndex(team => new
            {
                team.City,
                team.Name
            }).IsUnique();

            ConfigureEntityBase(entity);
        });
    }

    private static void ConfigureEntityBase<TEntity>(EntityTypeBuilder<TEntity> entity)
        where TEntity : EntityBase
    {
        entity.Property(item => item.CreatedOnUtc)
            .HasColumnName("created_on_utc")
            .IsRequired();

        entity.Property(item => item.CreatedBy)
            .HasColumnName("created_by")
            .HasMaxLength(150);

        entity.Property(item => item.ModifiedOnUtc)
            .HasColumnName("modified_on_utc");

        entity.Property(item => item.ModifiedBy)
            .HasColumnName("modified_by")
            .HasMaxLength(150);

        entity.Property(item => item.IsDeleted)
            .HasColumnName("is_deleted")
            .HasDefaultValue(false)
            .IsRequired();

        entity.HasQueryFilter(item => !item.IsDeleted);
    }

    private void ApplyEntityBaseRules()
    {
        var nowUtc = DateTimeOffset.UtcNow;

        // Temporary placeholder until you wire up real auth/current-user tracking.
        const string systemUser = "system";

        foreach (EntityEntry<EntityBase> entry in ChangeTracker.Entries<EntityBase>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.MarkCreated(systemUser, nowUtc);
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Entity.MarkModified(systemUser, nowUtc);
            }

            if (entry.State == EntityState.Deleted)
            {
                entry.State = EntityState.Modified;
                entry.Entity.MarkDeleted(systemUser, nowUtc);
            }
        }
    }
}