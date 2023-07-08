using EMail.Domain.SeedWork;
using System;

namespace EMail.Domain.Entities
{
    public class EMailAccountEntity : BaseEntity, ILogicallyExcludableEntity, IAuditEntity
    {
        public EMailAccountEntity() { }

        public EMailAccountEntity(string serializedEntity) 
        {
            string[] data = serializedEntity.Split(';');
            if (data.Length == 6)
            {
                try
                {
                    Address = data[0];
                    IsDeleted = short.Parse(data[1]);
                    CreatedBy = short.Parse(data[2]);
                    CreatedOn = DateTime.Parse(data[3]);
                    ModifiedBy = string.IsNullOrWhiteSpace(data[4]) ? (short?)null : short.Parse(data[4]);
                    ModifiedOn = string.IsNullOrWhiteSpace(data[5]) ? (DateTime?)null : DateTime.Parse(data[5]);
                }
                catch (Exception) { }
            }
        }

        public string Address { get; set; }
        public short IsDeleted { get; set; }
        public short CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public short? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        #region [BaseEntity members]

        public override string Serialize()
        {
            return string.Join(';', 
                Address ?? string.Empty, 
                IsDeleted, 
                CreatedBy,
                CreatedOn,
                ModifiedBy?.ToString() ?? string.Empty,
                ModifiedOn?.ToString() ?? string.Empty);
        }

        #endregion
    }
}
