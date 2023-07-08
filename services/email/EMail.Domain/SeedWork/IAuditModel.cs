using EMail.Domain.Enums;
using System;

namespace EMail.Domain.SeedWork
{
    public interface IAuditModel
    {
        DateTime CreatedOn { get; set; }
        SourceAgent CreatedBy { get; set; }
        DateTime? ModifiedOn { get; set; }
        SourceAgent? ModifiedBy { get; set; }
    }
}
