using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sand.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sand.Api
{
    public class BaseDataMapping : BaseEntityMap<BaseData>
    {
        protected override void MapTable(EntityTypeBuilder<BaseData> builder)
        {
            //ToTable("basedata", "system");
        }
    }
}
