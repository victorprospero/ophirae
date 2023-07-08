namespace EMail.Domain.SeedWork
{
    public interface ILogicallyExcludableEntity
    {
        short IsDeleted { get; set; }
    }
}
