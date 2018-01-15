using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sand.Domain.Entities.Systems;

namespace Sand.Data.Mapping.Systems
{
    public class TenantMapping : BaseEntityMap<Tenant>
    {
        protected override void MapTable(EntityTypeBuilder<Tenant> builder)
        {

        }
        protected override void MapSoftDelete(EntityTypeBuilder<Tenant> builder)
        {
            builder.HasQueryFilter(t => t.IsDeleted == false);
        }
    }
}
