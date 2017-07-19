using Sand.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sand.Domain.Repositories
{
    public abstract class BaseRepository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> CreateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IList<TEntity> CreateList(IList<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task<IList<TEntity>> CreateListAsync(IList<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public TPrimaryKey CreateReturnId(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TPrimaryKey> CreateReturnIdAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TPrimaryKey id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TPrimaryKey id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Retrieve()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Retrieve(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IList<TEntity> RetrieveAll()
        {
            throw new NotImplementedException();
        }

        public Task<IList<TEntity>> RetrieveAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<TEntity>> RetrieveAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity RetrieveById(TPrimaryKey id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> RetrieveByIdAsync(TPrimaryKey id)
        {
            throw new NotImplementedException();
        }

        public IList<TEntity> RetrieveByIds(IList<TPrimaryKey> ids)
        {
            throw new NotImplementedException();
        }

        public Task<IList<TEntity>> RetrieveByIdsAsync(IList<TPrimaryKey> ids)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TPrimaryKey id, Action<TEntity> updateAction)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(TPrimaryKey id, Func<TEntity, Task> updateAction)
        {
            throw new NotImplementedException();
        }
    }
}
