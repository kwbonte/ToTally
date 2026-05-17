using ToTally.Application.DTOs.Leagues;
using ToTally.Application.Interfaces;

namespace ToTally.Infrastructure.Services;

public sealed class LeagueService : ILeagueService
{
    private readonly ILeagueRepository _leagueRepository;

    public LeagueService(ILeagueRepository leagueRepository)
    {
        _leagueRepository = leagueRepository;
    }

    public async Task<IReadOnlyList<LeagueListItem>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var leagues = await _leagueRepository.GetAllAsync(cancellationToken);

        return leagues
            .OrderBy(league => league.Name)
            .Select(league => new LeagueListItem
            {
                Id = league.Id,
                Name = league.Name,
                Abbreviation = league.Abbreviation,
                Sport = league.Sport
            })
            .ToList();
    }
}