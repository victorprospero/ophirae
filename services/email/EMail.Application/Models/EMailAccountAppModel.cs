using EMail.Application.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMail.Application.Models
{
    public class EMailAccountAppModel : BaseAppModel
    {
        public string Address { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}
