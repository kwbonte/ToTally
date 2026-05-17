using Microsoft.EntityFrameworkCore;
using ToTally.Domain.Leagues;

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
        });
    }
}