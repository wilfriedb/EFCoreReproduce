namespace EFCoreReproduce;

public abstract class BaseCreatedEntity<TKey>
{
    public required TKey Id { get; init; }
    public string? CreatedOn { get; set; }
}
