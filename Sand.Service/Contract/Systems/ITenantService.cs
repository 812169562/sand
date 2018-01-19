using Sand.Domain.Entities.Systems;
using Sand.Domain.Queries.Systems;
using Sand.Service.Dtos.Systems;

namespace Sand.Service.Contract.Systems
{
    public interface ITenantService : IService<TenantDto, TenantQuery, Tenant,int>
    {
    }
}
