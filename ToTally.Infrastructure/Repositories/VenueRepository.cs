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

    public async Task<IReadOnlyList<Venue>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

        return await dbContext.Venues
            .AsNoTracking()
            .Where(venue => !venue.IsDeleted)
            .ToListAsync(cancellationToken);
    }
}