using ToTally.Application.DTOs.Teams;

namespace ToTally.Application.Interfaces;

public interface ITeamRepository
{
    Task<List<TeamListItem>> GetAllTeamDumpAsync(CancellationToken cancellationToken = default);
}