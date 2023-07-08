using EMail.Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMail.Domain.SeedWork
{
    public interface IRepository<T> where T : BaseModel
    {
        Task<bool> Save(T model, SourceAgent savedBy);
        Task<IEnumerable<T>> List();
    }
}
