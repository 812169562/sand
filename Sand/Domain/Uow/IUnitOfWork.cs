using Sand.Dependency;
using System;
using System.Threading.Tasks;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using AspectCore.DynamicProxy.Parameters;

namespace Sand.Domain.Uow
{
    /// <summary>
    /// 工作单元
    /// </summary>
    public interface IUnitOfWork : IDisposable, IDependency
    {
        /// <summary>
        /// 跟踪号
        /// </summary>
        string TraceId { get; }
        /// <summary>
        /// 事务开始
        /// </summary>
        /// <param name="options">事务属性</param>
        /// <returns></returns>
        //IUnitOfWork Begin(UnitOfWorkOptions options = null);
        /// <summary>
        /// 提交事务
        /// </summary>
        void Complete();
        /// <summary>
        /// 提交事务
        /// </summary>
        Task CompleteAsync();
        /// <summary>
        /// 回滚事务
        /// </summary>
        void RollBack();
        /// <summary>
        /// 回滚事务
        /// </summary>
        Task RollBackAsync();
        /// <summary>
        /// 连接
        /// </summary>
        IDbConnection DbConnection { get; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        EntityEntry Entry([NotNullAttribute] object entity);
    }

    /// <summary>
    /// 事务属性
    /// </summary>
    public class UnitOfWorkOptions
    {

        public bool? IsTransactional { get; set; }

        public TimeSpan? Timeout { get; set; }
        public UnitOfWorkOptions()
        {
            IsTransactional = true;
        }
    }

}
