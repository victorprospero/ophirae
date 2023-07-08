using EMail.Domain.Models;
using EMail.Domain.SeedWork;

namespace EMail.Domain.Entities
{
    public interface IEMailRepository : IRepository<EMailAccountModel>
    {
    }
}
