using Sand.Domain.Repositories;
using Sand.Domain.Entities.Systems;
using Sand.Domain.Queries.Systems;
using System.Collections.Generic;

namespace Sand.Domain.Repositories.Systems
{
    /// <summary>
    /// 租户仓储
    /// </summary>
    public interface ITenantRepository : IRepository<Tenant, int>
    {
       List<Tenant> GetAllRelationTenant(TenantQuery query);
    }
}
