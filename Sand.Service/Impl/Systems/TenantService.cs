using System;
using System.Linq;
using System.Linq.Expressions;
using Sand.Domain.Uow;
using Sand.Extensions;
using Sand.Domain.Entities.Systems;
using Sand.Domain.Queries.Systems;
using Sand.Service.Dtos.Systems;
using Sand.Service.Contract.Systems;
using Sand.Data.Repositories.Systems;
using Sand.Domain.Repositories.Systems;

namespace Sand.Service.Impl.Systems
{
    /// <summary>
    /// 租户服务
    /// </summary>
    public class TenantService : BaseService<TenantDto, TenantQuery, Tenant, int>, ITenantService
    {
        /// <summary>
        /// 租户仓储
        /// </summary>
        private readonly ITenantRepository _tenantRepository;


        /// <summary>
        /// 租户仓储
        /// </summary>
        private readonly IDicRepository _dicRepository;

        /// <summary>
        /// 初始化租户服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="tenantRepository">租户仓储</param>
        public TenantService(IUnitOfWork uow, ITenantRepository tenantRepository, IDicRepository dicRepository)
            : base(uow, tenantRepository)
        {
            _tenantRepository = tenantRepository;
            _dicRepository = dicRepository;
        }

        public TenantDto Test(Tenant dto)
        {
            var entity = _tenantRepository.RetrieveById(35);
            return ToDto(entity);
        }

        /// <summary>
        /// 创建租户条件表达式
        /// </summary>
        /// <param name="query">租户查询对象</param>
        /// <returns>租户查询表达式</returns>
        protected override Expression<Func<Tenant, bool>> CreateQuery(TenantQuery tenantQuery)
        {
            return base.CreateQuery(tenantQuery);
        }
    }
}