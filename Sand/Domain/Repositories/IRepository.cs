using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Sand.Dependency;
using Sand.Domain.Entities;

namespace Sand.Domain.Repositories
{
    /// <summary>
    /// 仓储接口
    /// </summary>
    public interface IRepository : IDependency
    {
    }

    /// <summary>
    /// 仓储接口
    /// </summary>
    /// <typeparam name="TEntity">实体</typeparam>
    public interface IRepository<TEntity> : IRepository<TEntity, Guid> where TEntity : class, IEntity<Guid>
    {

    }
    /// <summary>
    /// 仓储接口
    /// </summary>
    /// <typeparam name="TEntity">实体</typeparam>
    /// <typeparam name="TPrimaryKey">主键</typeparam>
    public interface IRepository<TEntity, TPrimaryKey> : IRepository where TEntity : class, IEntity<TPrimaryKey>
    {
        #region Create

        /// <summary>
        /// 创建实体
        /// </summary>
        /// <param name="entity">实体</param>
        TEntity Create(TEntity entity);

        /// <summary>
        /// 创建实体
        /// </summary>
        /// <param name="entity">实体</param>
        Task<TEntity> CreateAsync(TEntity entity);

        /// <summary>
        /// 创建实体集
        /// </summary>
        /// <param name="entities">实体集</param>
        /// <returns>创建后的实体集</returns>
        IList<TEntity> CreateList(IList<TEntity> entities);

        /// <summary>
        /// 创建实体集
        /// </summary>
        /// <param name="entities">实体集</param>
        /// <returns>创建后的实体集</returns>
        Task<IList<TEntity>> CreateListAsync(IList<TEntity> entities);

        /// <summary>
        /// 创建实体返回编号
        /// </summary>
        /// <param name="entity">实体</param>
        TPrimaryKey CreateReturnId(TEntity entity);

        /// <summary>
        /// 创建实体返回编号
        /// </summary>
        /// <param name="entity">实体</param>
        Task<TPrimaryKey> CreateReturnIdAsync(TEntity entity);
        #endregion

        #region Retrieve

        /// <summary>
        /// 获取实体查询对象
        /// </summary>
        /// <returns>查询对象</returns>
        IQueryable<TEntity> Retrieve();

        /// <summary>
        /// 查询对象
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns>实体对象</returns>
        IQueryable<TEntity> Retrieve(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 查询对象
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns>实体对象</returns>
        Task<IQueryable<TEntity>> RetrieveAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 根据编号查询实体
        /// </summary>
        /// <param name="id">实体编号</param>
        /// <returns>创建后的实体集</returns>
        TEntity RetrieveById(TPrimaryKey id);

        /// <summary>
        /// 根据编号查询实体
        /// </summary>
        /// <param name="id">实体编号</param>
        /// <returns>实体集</returns>
        Task<TEntity> RetrieveByIdAsync(TPrimaryKey id);

        /// <summary>
        /// 根据编号集合查询实体
        /// </summary>
        /// <param name="ids">实体编号集合</param>
        /// <returns>实体集</returns>
        IList<TEntity> RetrieveByIds(IList<TPrimaryKey> ids);

        /// <summary>
        /// 根据编号集合查询实体
        /// </summary>
        /// <param name="ids">实体编号集合</param>
        /// <returns>实体集</returns>
        Task<IList<TEntity>> RetrieveByIdsAsync(IList<TPrimaryKey> ids);

        /// <summary>
        /// 获取所有集合
        /// </summary>
        /// <returns>获取所有集合</returns>
        IList<TEntity> RetrieveAll();

        /// <summary>
        /// 获取所有集合
        /// </summary>
        /// <returns>获取所有集合</returns>
        Task<IList<TEntity>> RetrieveAllAsync();

        #endregion

        #region Update
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity">更新实体</param>
        /// <returns>更新后实体</returns>
        TEntity Update(TEntity entity);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity">更新实体</param>
        /// <returns>更新后实体</returns>
        Task<TEntity> UpdateAsync(TEntity entity);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="id">实体编号</param>
        /// <param name="updateAction">更新动作</param>
        /// <returns></returns>
        TEntity Update(TPrimaryKey id, Action<TEntity> updateAction);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="id">实体编号</param>
        /// <param name="updateAction">更新动作</param>
        /// <returns></returns>
        Task<TEntity> UpdateAsync(TPrimaryKey id, Func<TEntity, Task> updateAction);
        #endregion

        #region Delete

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity">删除实体</param>
        void Delete(TEntity entity);
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity">删除实体</param>
        Task DeleteAsync(TEntity entity);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">实体编号</param>
        void Delete(TPrimaryKey id);
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">实体编号</param>
        /// <returns></returns>
        Task DeleteAsync(TPrimaryKey id);
        #endregion

        #region Count
        /// <summary>
        /// 获取条数
        /// </summary>
        /// <param name="predicate">表达式</param>
        /// <returns></returns>
        int Count(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// 获取条数
        /// </summary>
        /// <param name="predicate">表达式</param>
        /// <returns></returns>
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);

        #endregion
    }
}
