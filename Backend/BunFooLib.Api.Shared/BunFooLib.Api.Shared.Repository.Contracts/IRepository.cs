using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BunFooLib.Api.Shared.Repository.Contracts
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task Create(TEntity entity);
        Task<TEntity?> ReadById(int id);
        Task<IEnumerable<TEntity>>Read();
        Task<IEnumerable<TEntity>> ReadByExpression(Expression<Func<TEntity, bool>> predicate);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
    }
}
