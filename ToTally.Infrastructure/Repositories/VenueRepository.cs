using Microsoft.EntityFrameworkCore;
using ToTally.Application.Interfaces;
using ToTally.Domain.Venues;
using ToTally.Infrastructure.Data;

namespace ToTally.Infrastructure.Repositories;

public sealed class VenueRepository : IVenueRepository
{
    private readonly IDbContextFactory<ToTallyDbContext> _dbContextFactory;

    public VenueRepository(IDbContextFactory<ToTallyDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    #region Create
    public async Task<Venue> CreateAsync(
        Venue venue,
        CancellationToken cancellationToken = default)
    {
        await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

        var createdVenue = (await dbContext.Venues.AddAsync(venue, cancellationToken)).Entity;

        await dbContext.SaveChangesAsync(cancellationToken);

        return createdVenue;
    }
    #endregion

    #region Read
    public async Task<IReadOnlyList<Venue>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

        return await dbContext.Venues
            .AsNoTracking()
            .Where(venue => !venue.IsDeleted)
            .ToListAsync(cancellationToken);
    }
    #endregion
}