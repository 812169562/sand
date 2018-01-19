using Sand.Domain.Uow;
using Sand.Domain.Repositories;
using Sand.Domain.Entities.Systems;
using Sand.Domain.Repositories.Systems;

namespace Sand.Data.Repositories.Systems
{
    /// <summary>
    /// 租户仓储
    /// </summary>
    public class TenantRepository : EfRepository<Tenant, int>, ITenantRepository
    {
        /// <summary>
        /// 初始化租户仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public TenantRepository(IUnitOfWork uow) : base(uow)
        {
        }
    }
}
