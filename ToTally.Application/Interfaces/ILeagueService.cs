using ToTally.Application.DTOs.Leagues;

namespace ToTally.Application.Interfaces;

public interface ILeagueService
{
    Task<IReadOnlyList<LeagueListItem>> GetAllAsync(CancellationToken ctx = default);
}