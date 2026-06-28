using Microsoft.EntityFrameworkCore;
using ToTally.Application.DTOs.Teams;
using ToTally.Application.Interfaces;
using ToTally.Infrastructure.Data;

namespace ToTally.Infrastructure.Repositories;

public class TeamRepository : ITeamRepository
{
    private readonly ToTallyDbContext _dbContext;

    public TeamRepository(ToTallyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<TeamListItem>> GetAllTeamDumpAsync(CancellationToken cancellationToken = default)
    {
        return _dbContext.Teams
            .AsNoTracking()
            .Select(team => new TeamListItem
            {
                TeamId = team.Id,
                City = team.City,
                Name = team.Name,
                Abbreviation = team.Abbreviation,

                DivisionId = team.Division.Id,
                DivisionName = team.Division.Name,
                DivisionAbbreviation = team.Division.Abbreviation,

                ConferenceId = team.Division.Conference.Id,
                ConferenceName = team.Division.Conference.Name,
                ConferenceAbbreviation = team.Division.Conference.Abbreviation,

                LeagueId = team.Division.Conference.League.Id,
                LeagueName = team.Division.Conference.League.Name,
                LeagueAbbreviation = team.Division.Conference.League.Abbreviation,
                Sport = team.Division.Conference.League.Sport,

                VenueId = team.Venue.Id,
                VenueName = team.Venue.Name,
                VenueCity = team.Venue.City,
                VenueStateOrCountry = team.Venue.StateOrCountry
            })
            .OrderBy(team => team.Name)
            .ToListAsync(cancellationToken);
    }
}