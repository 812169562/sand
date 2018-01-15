using Sand.Data.Repositories.Systems;
using Sand.Domain.Entities.Systems;
using Sand.Domain.Queries.Systems;
using Sand.Domain.Repositories;
using Sand.Domain.Uow;
using Sand.Service.Contact.Systems;
using Sand.Service.Dtos.Systems;
using System;

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
        private readonly ITenantRepository _dicRepository;
        /// <summary>
        /// 租户服务
        /// </summary>
        /// <param name="uow">工作单元</param>
        /// <param name="dicRepository">租户仓储</param>
        public TenantService(IUnitOfWork uow, ITenantRepository dicRepository) : base(uow, dicRepository)
        {
            _dicRepository = dicRepository;
        }
    }
}
