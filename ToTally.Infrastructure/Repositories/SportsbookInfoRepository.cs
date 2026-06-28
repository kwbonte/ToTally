using Microsoft.EntityFrameworkCore;
using ToTally.Application.DTOs.Sportsbook;
using ToTally.Application.Interfaces;
using ToTally.Domain.SportsBook;
using ToTally.Infrastructure.Data;

namespace ToTally.Infrastructure.Repositories;

public sealed class SportsbookInfoRepository : ISportsbookInfoRepository
{
    private readonly ToTallyDbContext _dbContext;

    public SportsbookInfoRepository(ToTallyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<TeamWinTotal>> GetCurrentTeamWinTotalsAsync(
        int seasonYear,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.TeamWinTotals
            .AsNoTracking()
            .Where(teamWinTotal => teamWinTotal.SeasonYear == seasonYear)
            .ToListAsync(cancellationToken);
    }

    // public async Task AddTeamWinTotalAsync(
    //     AddTeamWinTotalRequest request,
    //     CancellationToken cancellationToken = default)
    // {
    //     var entity = new SportsbookTeamWinTotal
    //     {
    //         TeamId = request.TeamId,
    //         SportsbookId = request.SportsbookId,
    //         SeasonYear = request.SeasonYear,
    //         Total = request.Total,
    //         OverAmericanOdds = request.OverOddsAmerican,
    //         UnderAmericanOdds = request.UnderOddsAmerican,
    //         ObservedOnUtc = request.ObservedOnUtc ?? DateTimeOffset.UtcNow
    //     };

    //     _dbContext.SportsbookTeamWinTotals.Add(entity);
    //     await _dbContext.SaveChangesAsync(cancellationToken);
    // }
}