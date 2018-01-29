using Sand.Domain.Uow;
using Sand.Domain.Repositories;
using Sand.Domain.Entities;
using Sand.Domain.Entities.Systems;

namespace Sand.Data.Repositories.Systems
{
    /// <summary>
    /// 字典表仓储
    /// </summary>
    public class DicsRepository : EfRepository<Dics>, IDicsRepository {
        /// <summary>
        /// 初始化字典表仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public DicsRepository( IUnitOfWork uow ) : base( uow ) {
        }
    }
}
