using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Sand.Domain.Entities;
using Sand.Dependency;

namespace Sand.Api
{
    [Table("Dics")]
    public class BaseData : Entity<Guid>,ISoftDelete
    {
        public string Code { get; set; }
        public bool IsDeleted { get; set; }
        public int Status { get; set; }
        public int Type { get; set; }
        public int Sort { get; set; }
        public string Name { get; set; }
        public string PinYin { get; set; }
        public string FullPinYin { get; set; }
        public string Wubi { get; set; }
        public string RelationShip { get; set; }
        public string Parent { get; set; }
        public  int Level { get; set; }

        public override void Load(IEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
