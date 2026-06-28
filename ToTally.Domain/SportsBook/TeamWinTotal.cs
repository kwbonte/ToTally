namespace ToTally.Domain.SportsBook;

using ToTally.Domain.Common;
using ToTally.Domain.Teams;

public sealed class TeamWinTotal : EntityBase
{
    private TeamWinTotal()
    {
    }

    public TeamWinTotal(
        int teamId,
        Guid sportsbookId,
        int seasonYear,
        decimal total,
        int? overAmericanOdds,
        int? underAmericanOdds,
        DateTimeOffset observedOnUtc)
    {
        Id = Guid.NewGuid();
        TeamId = teamId;
        SportsbookId = sportsbookId;
        SeasonYear = seasonYear;
        Total = total;
        OverAmericanOdds = overAmericanOdds;
        UnderAmericanOdds = underAmericanOdds;
        ObservedOnUtc = observedOnUtc;
    }

    public Guid Id { get; private set; }

    public int TeamId { get; private set; }

    public Guid SportsbookId { get; private set; }

    public int SeasonYear { get; private set; }

    public decimal Total { get; private set; }

    public int? OverAmericanOdds { get; private set; }

    public int? UnderAmericanOdds { get; private set; }

    public DateTimeOffset ObservedOnUtc { get; private set; }

    public Team Team { get; private set; } = null!;

    public Sportsbook Sportsbook { get; private set; } = null!;
}