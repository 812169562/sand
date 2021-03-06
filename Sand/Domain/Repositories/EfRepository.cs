﻿using System;
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
using AspectCore.Injector;
using Dapper;
using Sand.Context;
using Sand.Exceptions;

namespace Sand.Domain.Repositories
{
    public class EfRepository<TEntity, TPrimaryKey> : BaseRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        public virtual DbSet<TEntity> Table { get { return Uow.Set<TEntity>(); } }

        protected new IUnitOfWork Uow { get; set; }

        public EfRepository(IUnitOfWork uow) : base(uow)
        {
            Uow = base.Uow;
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
            //entity.Init();
            entity.SetCreateUser(UserContext);
            entity.Validation();
            Table.Add(entity);
            return entity;
        }
        public override IList<TEntity> CreateList(IList<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                //entity.Init();
                entity.SetCreateUser(UserContext);
                entity.Validation();
            }
            Table.AddRange(entities);
            return entities;
        }

        public override TPrimaryKey CreateReturnId(TEntity entity)
        {
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
            entity.Init();
            entity.SetUpdateUser(UserContext);
            entity.Validation();
            AttachIfNot(entity);
            Uow.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public override TEntity Update(TPrimaryKey id, Action<TEntity> updateAction)
        {
            var entity = RetrieveById(id);
            updateAction(entity);
            return entity;
        }

        public override async Task<TEntity> UpdateAsync(TPrimaryKey id, Func<TEntity, Task> updateAction)
        {
            var entity = await RetrieveByIdAsync(id);
            await updateAction(entity);
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
                    throw new Warning("当前操作数据不是最新数据,请重新刷新页面再操作！");
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
            entity.Init();
            entity.SetUpdateUser(UserContext);
            AttachIfNot(entity);
            if (entity is ISoftDelete)
            {
                ((ISoftDelete)entity).IsDeleted = true;
                Uow.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                Table.Remove(entity);
            }
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
        public EfRepository(IUnitOfWork uow) : base(uow)
        {
        }
    }
}
