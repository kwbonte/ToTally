namespace ToTally.Domain.Common;
public abstract class EntityBase
{
    public DateTimeOffset CreatedOnUtc { get; private set; }
    public string? CreatedBy { get; private set; }

    public DateTimeOffset? ModifiedOnUtc { get; private set; }
    public string? ModifiedBy { get; private set; }

    public bool IsDeleted { get; private set; }

    public void MarkCreated(string? userId, DateTimeOffset nowUtc)
    {
        CreatedOnUtc = nowUtc;
        CreatedBy = userId;
        IsDeleted = false;
    }

    public void MarkModified(string? userId, DateTimeOffset nowUtc)
    {
        ModifiedOnUtc = nowUtc;
        ModifiedBy = userId;
    }

    public void MarkDeleted(string? userId, DateTimeOffset nowUtc)
    {
        if (IsDeleted)
        {
            return;
        }

        IsDeleted = true;
        MarkModified(userId, nowUtc);
    }

    public void Restore(string? userId, DateTimeOffset nowUtc)
    {
        if (!IsDeleted)
        {
            return;
        }

        IsDeleted = false;
        MarkModified(userId, nowUtc);
    }
}