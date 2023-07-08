using EMail.Domain.Enums;
using EMail.Domain.SeedWork;
using System;

namespace EMail.Domain.Models
{
    public class EMailAccountModel : BaseModel, IAuditModel, ILogicallyExcludableModel
    {
        public string Address { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public SourceAgent CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public SourceAgent? ModifiedBy { get; set; }
    }
}
