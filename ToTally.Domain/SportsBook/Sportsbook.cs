using ToTally.Domain.Common;

namespace ToTally.Domain.SportsBook;

public class Sportsbook : EntityBase
{
    private Sportsbook()
    {
    }

    public Sportsbook(string name, string code)
    {
        Name = name;
        Code = code;
        IsActive = true;
    }

    public Guid Id { get; private set; }

    public string Name { get; private set; } = null!;

    public string Code { get; private set; } = null!;

    public bool IsActive { get; private set; }

    public void Update(string name, string code)
    {
        Name = name;
        Code = code;
    }

    public void Activate()
    {
        IsActive = true;
    }

    public void Deactivate()
    {
        IsActive = false;
    }
}