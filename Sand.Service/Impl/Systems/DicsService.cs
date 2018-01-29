using System;
using System.Linq;
using System.Linq.Expressions;
using Sand.Domain.Uow;
using Sand.Extensions;
using Sand.Domain.Entities.Systems;
using Sand.Domain.Queries.Systems;
using Sand.Service.Dtos.Systems;
using Sand.Service.Contract.Systems;
using Sand.Domain.Repositories;

namespace Sand.Service.Impl.Systems
{
    /// <summary>
    /// 字典表服务
    /// </summary>
    public class DicsService : BaseService<DicsDto, DicsQuery, Dics, Guid>, IDicsService
    {
        /// <summary>
        /// 字典表仓储
        /// </summary>
        private readonly IDicsRepository _dicsRepository;

        /// <summary>
        /// 初始化字典表服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="dicsRepository">字典表仓储</param>
        public DicsService(IUnitOfWork uow, IDicsRepository dicsRepository)
            : base(uow, dicsRepository)
        {
            _dicsRepository = dicsRepository;
        }

        /// <summary>
        /// 创建字典表条件表达式
        /// </summary>
        /// <param name="query">字典表查询对象</param>
        /// <returns>字典表查询表达式</returns>
        protected override Expression<Func<Dics, bool>> CreateQuery(DicsQuery dicsQuery)
        {
            var queryWhere = base.CreateQuery(dicsQuery);
            queryWhere.WhereIf(t => t.Parent == dicsQuery.Parent, dicsQuery.Parent.IsNotEmpty());
            return queryWhere;
        }
    }
}