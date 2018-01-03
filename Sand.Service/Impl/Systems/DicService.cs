using Sand.Data.Repositories.Systems;
using Sand.Domain.Entities.Systems;
using Sand.Domain.Queries.Systems;
using Sand.Domain.Repositories;
using Sand.Domain.Uow;
using Sand.Service.Contact.Systems;
using Sand.Service.Dtos.Systems;
using System;

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
