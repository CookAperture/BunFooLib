using BunFooLib.Api.Shared.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunFooLib.Api.Shared.Repository
{
    public class Repository<TEntity, TContext> : IRepository<TEntity> 
        where TEntity : class 
        where TContext : DbContext
    {
        private readonly TContext _dbContext;

        public Repository(TContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<TEntity> ReadById(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> Read()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> ReadByExpression(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbContext.Set<TEntity>()
                   .Where(predicate)
                   .ToListAsync();
        }

        public virtual async Task Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task Create(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
