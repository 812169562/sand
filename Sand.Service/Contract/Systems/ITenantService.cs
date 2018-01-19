using Sand.Domain.Queries.Systems;
using Sand.Domain.Entities.Systems;
using Sand.Service.Dtos.Systems;

namespace Sand.Service.Contract.Systems
{
    /// <summary>
    /// 租户服务
    /// </summary>
    public interface ITenantService : IService<TenantDto, TenantQuery, Tenant, int>
    {
    }
}