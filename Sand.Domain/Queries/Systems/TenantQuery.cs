using Sand.Domain.Entities.Systems;
using Sand.Domain.Query;
namespace Sand.Domain.Queries.Systems
{
    public class TenantQuery : BaseQuery<Tenant, int>
    {
        public string TelName { get; set; }
    }
}
