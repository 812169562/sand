using Sand.Dependency;
using Sand.Domain.Query;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sand.Domain.Entities.Systems
{
    public class TenantQuery : BaseQuery<Tenant, int>
    {
        public string TelName { get; set; }
    }
}
