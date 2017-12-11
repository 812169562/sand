using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Sand.Context;
using Sand.Domain.Entities;
using Sand.Domain.Query;
using Sand.Domain.Repositories;
using Sand.Domain.Uow;
using Sand.Exceptions;
using Sand.Extensions;
using Sand.Helpers;
using Sand.Result;
using Sand.Maps;
using Sand.Extension;
using Sand.Lambdas.Dynamics;
using Microsoft.EntityFrameworkCore;

namespace Sand.Service
{
    /// <summary>
    /// 服务基类
    /// </summary>
    /// <typeparam name="TDto">传输对象</typeparam>
    /// <typeparam name="TQuery">查询对象</typeparam>
    /// <typeparam name="TEntity">实体对象</typeparam>
    /// <typeparam name="TPrimaryKey">提示主键</typeparam>
    public class BaseService<TDto, TQuery, TEntity, TPrimaryKey> : IService<TDto, TQuery, TEntity, TPrimaryKey> where TDto : BaseDto, new() where TQuery : IQuery<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>, new()
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        public IUserContext UserContext { get; set; }
        /// <summary>
        /// 日志信息
        /// </summary>
        public ILogger Logger { get; set; }
        /// <summary>
        /// 工作单元
        /// </summary>
        protected readonly IUnitOfWork Uow;
        /// <summary>
        /// 仓储
        /// </summary>
        protected readonly IRepository<TEntity, TPrimaryKey> Repository;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="uow">工作单元</param>
        /// <param name="repository">仓储</param>
        public BaseService(IUnitOfWork uow, IRepository<TEntity, TPrimaryKey> repository)
        {
            Uow = uow;
            Repository = repository;
        }

        /// <summary>
        /// 转为Dto
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>dto</returns>
        protected virtual TDto ToDto(TEntity entity)
        {
            entity.CheckNull("数据不能为空");
            var dto = new TDto();
            return entity.MapTo(dto);
        }
        /// <summary>
        /// 转为实体
        /// </summary>
        /// <param name="dto">dto</param>
        /// <returns>实体</returns>
        protected virtual TEntity ToEntity(TDto dto)
        {
            dto.CheckNull("数据不能为空");
            var entity = new TEntity();
            return dto.MapTo(entity);
        }

        /// <summary>
        /// 创建条件表达式
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns></returns>
        protected virtual Expression<Func<TEntity, bool>> CreateQuery(TQuery query)
        {
            return Extensions.Extensions.True<TEntity>();
        }

        /// <summary>
        /// 创建条件表达式
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns></returns>
        protected virtual void CreateOrder(TQuery query)
        {
            query.OrderBy(t => t.CreateTime);
        }

        /// <summary>
        /// 创建条件表达式
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns></returns>
        private string CreateOrderBy(TQuery query)
        {
            CreateOrder(query);
            return query.GetOrderBy();
        }

        public TDto Create(TDto dto)
        {
            var result = Repository.Create(ToEntity(dto));
            return ToDto(result);
        }

        public virtual async Task<TDto> CreateAsync(TDto dto)
        {

            var result = await Repository.CreateAsync(ToEntity(dto));
            Uow.Complete();
            return ToDto(result);
        }

        /// <summary>
        /// 更新或者插入
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>

        public virtual TDto CreateOrUpdate(TDto dto)
        {

            TEntity result = null;
            if (dto.Id.IsEmpty())
                result = Repository.Create(ToEntity(dto));
            else
                result = Repository.Update(ToEntity(dto));
            return ToDto(result);
        }

        public virtual async Task<TDto> CreateOrUpdateAsync(TDto dto)
        {

            TEntity result = null;
            if (dto.Id.IsEmpty())
                result = await Repository.CreateAsync(ToEntity(dto));
            else
                result = await Repository.UpdateAsync(ToEntity(dto));
            return ToDto(result);
        }

        public virtual IList<TDto> CreateList(IList<TDto> dtos)
        {
            var result = Repository.CreateList(dtos.Select(ToEntity).ToList());
            return result.Select(ToDto).ToList();
        }

        public virtual async Task<IList<TDto>> CreateListAsync(IList<TDto> dtos)
        {
            var result = await Repository.CreateListAsync(dtos.Select(ToEntity).ToList());
            return result.Select(ToDto).ToList();
        }

        public virtual TPrimaryKey CreateReturnId(TDto dto)
        {
            var result = Repository.CreateReturnId(ToEntity(dto));
            return result;
        }

        public virtual async Task<TPrimaryKey> CreateReturnIdAsync(TDto dto)
        {
            var result = await Repository.CreateReturnIdAsync(ToEntity(dto));
            return result;
        }

        public virtual IList<TDto> Retrieve(TQuery query)
        {
            var entity = query.IsTracking ? Repository.Retrieve(CreateQuery(query)).OrderByDynamic(CreateOrderBy(query)).AsNoTracking() : Repository.Retrieve(CreateQuery(query)).OrderByDynamic(CreateOrderBy(query));
            return entity.Select(ToDto).ToList();
        }

        public virtual async Task<IList<TDto>> RetrieveAsync(TQuery query)
        {
            var entity = await Repository.RetrieveAsync(CreateQuery(query));
            entity = entity.OrderByDynamic(CreateOrderBy(query));
            return entity.Select(ToDto).ToList();
        }

        public virtual TDto RetrieveById(TPrimaryKey id)
        {
            return ToDto(Repository.RetrieveById(id));
        }

        public virtual async Task<TDto> RetrieveByIdAsync(TPrimaryKey id)
        {
            var entity = await Repository.RetrieveByIdAsync(id);
            return ToDto(entity);
        }

        public virtual Paged<TDto> Page(TQuery query)
        {
            var where = CreateQuery(query);
            var data = Repository.Retrieve(where).OrderByDynamic(CreateOrderBy(query)).Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize);
            var count = Repository.Count(where);
            Paged<TDto> result = new Paged<TDto>();
            result.Result.AddRange(data.Select(ToDto));
            result.PageIndex = query.PageIndex;
            result.TotalCount = count;
            return result;
        }

        public virtual async Task<Paged<TDto>> PageAsync(TQuery query)
        {
            var where = CreateQuery(query);
            var data = await Repository.RetrieveAsync(where);
            var pagedata = data.OrderByDynamic(CreateOrderBy(query)).Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize);
            var page = await pagedata.ToListAsync();
            var count = Repository.Count(where);
            Paged<TDto> result = new Paged<TDto>();
            result.Result.AddRange(page.Select(ToDto));
            result.PageIndex = query.PageIndex;
            result.TotalCount = count;
            return result;
        }

        public virtual void Update(TDto dto)
        {
            Repository.Update(ToEntity(dto));
        }

        public virtual TDto UpdateReturn(TDto dto)
        {
            return ToDto(Repository.Update(ToEntity(dto)));
        }

        public virtual async Task UpdateAsync(TDto dto)
        {
            await Repository.UpdateAsync(ToEntity(dto));
        }

        public virtual async Task<TDto> UpdateReturnAsync(TDto dto)
        {
            var result = await Repository.UpdateAsync(ToEntity(dto));
            return ToDto(result);
        }

        public virtual void UpdateList(IList<TDto> dtos)
        {
            foreach (var dto in dtos)
            {
                Repository.Update(ToEntity(dto));
            }
        }

        public virtual IList<TDto> UpdateListReturn(IList<TDto> dtos)
        {
            IList<TDto> result = new List<TDto>();
            foreach (var dto in dtos)
            {
                var entity = Repository.Update(ToEntity(dto));
                result.Add(ToDto(entity));
            }
            return result;
        }

        public virtual async Task UpdateListAsync(IList<TDto> dtos)
        {
            foreach (var dto in dtos)
            {
                await Repository.UpdateAsync(ToEntity(dto));
            }
        }

        public virtual async Task<IList<TDto>> UpdateListReturnAsync(IList<TDto> dtos)
        {
            IList<TDto> result = new List<TDto>();
            foreach (var dto in dtos)
            {
                var entity = await Repository.UpdateAsync(ToEntity(dto));
                result.Add(ToDto(entity));
            }
            return result;
        }

        public virtual void Delete(IList<TPrimaryKey> ids)
        {
            foreach (var id in ids)
                Repository.Delete(id);
        }

        public virtual async Task DeleteAsync(IList<TPrimaryKey> ids)
        {
            foreach (var id in ids)
                await Repository.DeleteAsync(id);
        }

        public virtual void Delete(IList<TDto> dtos)
        {
            var entityes = dtos.Select(ToEntity).ToList();
            var entity = Repository.RetrieveByIds(entityes.Select(t => t.Id).ToList());
            foreach (var each in entity)
            {
                Repository.Delete(each);
            }
        }

        public virtual async Task DeleteAsync(IList<TDto> dtos)
        {
            var beforeEntities = dtos.Select(ToEntity).ToList();
            var entities = await Repository.RetrieveByIdsAsync(beforeEntities.Select(t => t.Id).ToList());
            CheckVersion(dtos.Select(t => t.Version), entities.Select(t => t.Version));
            foreach (var each in entities)
            {
                await Repository.DeleteAsync(each);
            }
            await Uow.CompleteAsync();
        }
        /// <summary>
        /// 验证数据过期
        /// </summary>
        /// <param name="updateVersion">更新前数据</param>
        /// <param name="dbVersion">数据库数据</param>
        private void CheckVersion(IEnumerable<byte[]> updateVersion, IEnumerable<byte[]> dbVersion)
        {
            if (updateVersion == null || dbVersion == null)
                throw new Warning("已经不是最新数据,请重新刷新页面再操作！");
            if (!updateVersion.Any() || !dbVersion.Any())
                throw new Warning("已经不是最新数据,请重新刷新页面再操作！");
            if (updateVersion.Any(top => dbVersion.Any(top.NotEqual)))
                throw new Warning("已经不是最新数据,请重新刷新页面再操作！");
        }

        Paged<TDto> IService<TDto, TQuery, TEntity, TPrimaryKey>.Page(TQuery query)
        {
            throw new NotImplementedException();
        }

        Task<Paged<TDto>> IService<TDto, TQuery, TEntity, TPrimaryKey>.PageAsync(TQuery query)
        {
            throw new NotImplementedException();
        }
    }


    public class BaseService<TDto, TQuery, TEntity> : BaseService<TDto, TQuery, TEntity, Guid>
        where TDto : BaseDto, new()
        where TQuery : IQuery<TEntity, Guid>
        where TEntity : class, IEntity<Guid>, new()
    {
        public BaseService(IUnitOfWork uow, IRepository<TEntity> repository) : base(uow, repository)
        {
        }
    }
}
