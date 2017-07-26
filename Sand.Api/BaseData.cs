using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Sand.Domain.Entities;
using Sand.Dependency;

namespace Sand.Api
{
    [Table("BaseData")]
    public class BaseData : Entity<Guid>,ISoftDelete
    {
        public bool IsDeleted { get; set; }

        public override void Init()
        {
            throw new NotImplementedException();
        }

        public override void Load(IEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
