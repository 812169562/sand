using Sand.Data.Repositories.Systems;
using Sand.Domain.Entities.Systems;
using Sand.Domain.Queries.Systems;
using Sand.Domain.Repositories.Systems;
using Sand.Domain.Uow;
using Sand.Service.Contract.Systems;
using Sand.Service.Dtos.Systems;

namespace Sand.Service.Impl.Systems
{
    public class DicService : BaseService<DicDto, DicQuery, Dic>, IDicService
    {
        private readonly IDicRepository _dicRepository;
        public DicService(IUnitOfWork uow, IDicRepository dicRepository) : base(uow, dicRepository)
        {
            _dicRepository = dicRepository;
        }
    }
}
