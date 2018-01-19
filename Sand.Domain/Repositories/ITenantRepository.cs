using Sand.Domain.Repositories;
using Sand.Domain.Entities.Systems;

namespace Sand.Domain.Repositories.Systems
{
    /// <summary>
    /// 租户仓储
    /// </summary>
    public interface ITenantRepository : IRepository<Tenant, int>
    {
    }
}
