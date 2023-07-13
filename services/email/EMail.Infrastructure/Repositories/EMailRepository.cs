using EMail.Domain.Entities;
using EMail.Domain.Enums;
using EMail.Domain.Models;
using EMail.Infrastructure.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMail.Infrastructure.Repositories
{
    public class EMailRepository : BaseRepository, IEMailRepository
    {
        public EMailRepository() : base("email-accounts.txt") { }

        public async Task<IEnumerable<EMailAccountModel>> List()
        {
            string data = await base.ReadData();

            IEnumerable<EMailAccountEntity> entities = from row in data.Split('\n') select new EMailAccountEntity(row);

            return entities.Where(x => x.CreatedOn > System.DateTime.MinValue)
                            .Select(y => new EMailAccountModel()
                            {
                                Address = y.Address,
                                CreatedBy = (SourceAgent)y.CreatedBy,
                                CreatedOn = y.CreatedOn,
                                IsDeleted = y.IsDeleted == 1,
                                ModifiedBy = (SourceAgent?)y.ModifiedBy,
                                ModifiedOn = y.ModifiedOn
                            });
        }

        public async Task<bool> Save(EMailAccountModel model, SourceAgent savedBy)
        {
            string data = await base.ReadData();
            List<EMailAccountEntity> resultSet = (from row in data.Split('\n') select new EMailAccountEntity(row)).Where(x => x.CreatedOn > System.DateTime.MinValue).ToList();

            EMailAccountEntity existing = resultSet.FirstOrDefault(x => x.Address == model.Address);

            if (existing == null)
            {
                resultSet.Add(new EMailAccountEntity()
                {
                    Address = model.Address,
                    CreatedBy = (short)savedBy,
                    CreatedOn = DateTime.Now,
                    IsDeleted = 0
                });
            } 
            else
            {
                if (existing.IsDeleted != 1) return false;
                existing.IsDeleted = 0;
                existing.ModifiedOn = DateTime.Now;
                existing.ModifiedBy = (short)savedBy;
            }

            return await base.SaveData<EMailAccountEntity>(resultSet);
        }
    }
}
