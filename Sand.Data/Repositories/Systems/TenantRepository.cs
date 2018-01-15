using Sand.Domain.Entities.Systems;
using Sand.Domain.Repositories;
using Sand.Domain.Uow;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sand.Data.Repositories.Systems
{
    /// <summary>
    /// 租户仓储
    /// </summary>
    public class TenantRepository : EfRepository<Tenant, int>, ITenantRepository
    {
        /// <summary>
        /// 租户仓储
        /// </summary>
        /// <param name="uow">工作单元</param>
        public TenantRepository(IUnitOfWork uow) : base(uow)
        {
        }
    }
}
