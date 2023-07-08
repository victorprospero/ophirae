using EMail.Domain.SeedWork;

namespace EMail.Domain.ValueObjects
{
    public class EMailAccountToSave : BaseValueObject
    {
        public string EMailAddress { get; set; }
        public string SavedBy { get; set; }
    }
}
