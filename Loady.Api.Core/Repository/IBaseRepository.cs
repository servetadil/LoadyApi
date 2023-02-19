using Loady.Api.Core.Entities.Base;
using System.Linq.Expressions;

namespace Loady.Api.Core.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> GetById(string id);

        Task<IEnumerable<T>> FilterBy(Expression<Func<T, bool>> wheres);
    }
}
