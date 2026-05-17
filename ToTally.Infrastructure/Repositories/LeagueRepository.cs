using Microsoft.EntityFrameworkCore;
using ToTally.Application.Interfaces;
using ToTally.Domain.Leagues;
using ToTally.Infrastructure.Data;

namespace ToTally.Infrastructure.Repositories;

public sealed class LeagueRepository : ILeagueRepository
{
    private readonly IDbContextFactory<ToTallyDbContext> _dbContextFactory;

    public LeagueRepository(IDbContextFactory<ToTallyDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task<IReadOnlyList<League>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

        return await dbContext.Leagues
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}