using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BunFooLib.Api.Shared.Repository.Contracts
{
    public interface IRepository<T> where T : class
    {
        void Create(T entity);
        T? ReadById(int id);
        IEnumerable<T> Read();
        IEnumerable<T> ReadByExpression(Expression<Func<T, bool>> predicate);
        void Update(T entity);
        void Delete(T entity);
    }
}
