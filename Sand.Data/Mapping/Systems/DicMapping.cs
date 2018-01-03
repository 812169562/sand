using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sand.Domain.Entities.Systems;

namespace Sand.Data.Mapping.Systems
{
    public class DicMapping : BaseEntityMap<Dic>
    {
        protected override void MapTable(EntityTypeBuilder<Dic> builder)
        {

        }

        protected override void MapSoftDelete(EntityTypeBuilder<Dic> builder)
        {
            builder.HasQueryFilter(t => t.IsDeleted == false);
        }
    }
}
