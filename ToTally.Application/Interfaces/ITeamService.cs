using ToTally.Application.DTOs.Teams;

namespace ToTally.Application.Interfaces;

public interface ITeamService
{
    Task<List<TeamListItem>> GetAllTeamDumpAsync(CancellationToken cancellationToken = default);
    // get all by league
    // get all by conference
    // get all by division
}