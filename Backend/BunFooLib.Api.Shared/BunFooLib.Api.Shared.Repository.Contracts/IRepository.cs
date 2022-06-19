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
        void Create(TEntity entity);
        TEntity? ReadById(int id);
        IEnumerable<TEntity> Read();
        IEnumerable<TEntity> ReadByExpression(Expression<Func<TEntity, bool>> predicate);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
