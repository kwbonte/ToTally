using Microsoft.EntityFrameworkCore;
using ToTally.Application.DTOs.Leagues;
using ToTally.Application.Interfaces;
using ToTally.Infrastructure.Data;

namespace ToTally.Infrastructure.Services;

public sealed class LeagueService : ILeagueService
{
    private readonly IDbContextFactory<ToTallyDbContext> _dbContextFactory;

    public LeagueService(IDbContextFactory<ToTallyDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task<IReadOnlyList<LeagueListItem>> GetAllAsync(CancellationToken ctx)
    {
        await using var dbContext = await _dbContextFactory.CreateDbContextAsync(ctx);

        return await dbContext.Leagues
            .AsNoTracking()
            .OrderBy(league => league.Name)
            .Select(league => new LeagueListItem
            {
                Id = league.Id,
                Name = league.Name,
                Abbreviation = league.Abbreviation,
                Sport = league.Sport
            })
            .ToListAsync(ctx);
    }
}