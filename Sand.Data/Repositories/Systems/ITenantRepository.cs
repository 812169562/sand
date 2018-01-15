using Sand.Domain.Entities.Systems;
using Sand.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sand.Data.Repositories.Systems
{
    /// <summary>
    /// 租户仓储
    /// </summary>
    public interface ITenantRepository : IRepository<Tenant, int>
    {
    }
}
