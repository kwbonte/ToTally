using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToTally.Domain.Common;
using ToTally.Domain.Leagues;
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

        entity.Property(item => item.DeletedOnUtc)
            .HasColumnName("deleted_on_utc");

        entity.Property(item => item.DeletedBy)
            .HasColumnName("deleted_by")
            .HasMaxLength(150);

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