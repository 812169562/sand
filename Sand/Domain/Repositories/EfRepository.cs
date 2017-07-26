using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sand.Dependency;
using Sand.Domain.Entities;
using Sand.Domain.Uow;
using Sand.Filter;

namespace Sand.Domain.Repositories
{
    public class EfRepository<TEntity, TPrimaryKey> : BaseRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        public virtual DbSet<TEntity> Table { get { return Uow.Set<TEntity>(); } }

        protected new EfUnitOfWork Uow { get; set; }

        public EfRepository(IUnitOfWork uow):base(uow)
        {
            Uow = (EfUnitOfWork)base.Uow;
        }

        protected virtual void AttachIfNot(TEntity entity)
        {
            if (!Table.Local.Contains(entity))
            {
                Table.Attach(entity);
            }
        }

        public override TEntity Create(TEntity entity)
        {
            //entity.SetCreator(UserContext);
            //entity.Validate();
            //Table.Add(entity);
            AttachIfNot(entity);
            Uow.Entry(entity).State = EntityState.Added;
            Uow.SaveChanges();
            return entity;
        }
        public override IList<TEntity> CreateList(IList<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                //entity.SetCreator(UserContext);
               // entity.Validate();
            }
            Table.AddRange(entities);
            //Uow.Entry(entities).State = EntityState.Added;
            Uow.SaveChanges();
            return entities;
        }

        public override TPrimaryKey CreateReturnId(TEntity entity)
        {
           // entity.SetCreator(UserContext);
            //entity.Validate();
            return Create(entity).Id;
        }

        public override IQueryable<TEntity> Retrieve()
        {
            return Table;
        }

        public override IQueryable<TEntity> Retrieve(Expression<Func<TEntity, bool>> predicate)
        {
            return Table.Where(predicate);
        }

        public override TEntity RetrieveById(TPrimaryKey id)
        {
            return Table.Find(id);
        }

        public override IList<TEntity> RetrieveByIds(IList<TPrimaryKey> ids)
        {
            return Table.Where(t => ids.Contains(t.Id)).ToList();
        }

        public override TEntity Update(TEntity entity)
        {
            //entity.SetUpdate(UserContext);
            //entity.Validate();
            AttachIfNot(entity);
            Uow.Entry(entity).State = EntityState.Modified;
            Uow.SaveChanges();
            return entity;
        }

        public override TEntity Update(TPrimaryKey id, Action<TEntity> updateAction)
        {
            var entity = RetrieveById(id);
            //entity.SetUpdate(UserContext);
            updateAction(entity);
            return entity;
        }

        public override async Task<TEntity> UpdateAsync(TPrimaryKey id, Func<TEntity, Task> updateAction)
        {
            var entity = await RetrieveByIdAsync(id);
            await updateAction(entity);
            //entity.SetUpdate(UserContext);
            return entity;
        }

        public override void Delete(TPrimaryKey id)
        {
            var entity = Table.Local.FirstOrDefault(ent => EqualityComparer<TPrimaryKey>.Default.Equals(ent.Id, id));
            if (entity == null)
            {
                entity = RetrieveById(id);
                if (entity == null)
                {
                    return;
                }
            }
            Delete(entity);
        }

        public override int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return Table.Where(predicate).Count();
        }

        public override Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Table.Where(predicate).CountAsync();
        }

        public override void Delete(TEntity entity)
        {
           // entity.SetUpdate(UserContext);
            AttachIfNot(entity);
            if (entity is ISoftDelete)
            {
                ((ISoftDelete)entity).IsDeleted = true;
                Uow.Entry(entity).State = EntityState.Modified;
            }
            else
                Table.Remove(entity);
        }

        public override void Delete(IList<TPrimaryKey> ids)
        {
            throw new NotImplementedException();
        }

        public override IList<TEntity> RetrieveAll()
        {
            throw new NotImplementedException();
        }
    }

    public class EfRepository<TEntity> : EfRepository<TEntity, Guid> where TEntity : class, IEntity<Guid>
    {
        public EfRepository(IUnitOfWork uow):base(uow)
        {
        }
    }
}
