using ToTally.Application.DTOs.Sportsbook;
using ToTally.Application.Interfaces;

namespace ToTally.Application.Services;


public sealed class SportsbookInfoService : ISportsbookInfoService
{
    private readonly ISportsbookInfoRepository _sportsbookInfoRepository;

    public SportsbookInfoService(ISportsbookInfoRepository sportsbookInfoRepository)
    {
        _sportsbookInfoRepository = sportsbookInfoRepository;
    }

    public async Task<IReadOnlyList<SportsbookTeamWinTotalInfo>> GetCurrentTeamWinTotalsAsync(
        int seasonYear,
        CancellationToken cancellationToken = default)
    {
        var teamWinTotals = await _sportsbookInfoRepository.GetCurrentTeamWinTotalsAsync(seasonYear, cancellationToken);

        return teamWinTotals.Select(twt => new SportsbookTeamWinTotalInfo
        {
            TeamId = twt.TeamId,
            TeamCity = twt.Team?.City ?? string.Empty,
            TeamName = twt.Team?.Name ?? string.Empty,
            TeamAbbreviation = twt.Team?.Abbreviation ?? string.Empty,
            SportsbookId = twt.SportsbookId,
            SportsbookName = twt.Sportsbook?.Name ?? string.Empty,
            SportsbookCode = twt.Sportsbook?.Code ?? string.Empty,
            SeasonYear = twt.SeasonYear,
            Total = twt.Total,
            OverAmericanOdds = twt.OverAmericanOdds,
            UnderAmericanOdds = twt.UnderAmericanOdds,
            ObservedOnUtc = twt.ObservedOnUtc
        }).ToList();
    }
}