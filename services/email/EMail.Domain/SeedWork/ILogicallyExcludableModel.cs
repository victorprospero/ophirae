namespace EMail.Domain.SeedWork
{
    interface ILogicallyExcludableModel
    {
        public bool IsDeleted { get; set; }
    }
}
