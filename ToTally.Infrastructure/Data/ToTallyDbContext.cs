using Microsoft.EntityFrameworkCore;
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
        });
    }
}