using System;

namespace EMail.Domain.SeedWork
{
    public interface IAuditEntity
    {
        short CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }
        short? ModifiedBy { get; set; }
        DateTime? ModifiedOn { get; set; }
    }
}
