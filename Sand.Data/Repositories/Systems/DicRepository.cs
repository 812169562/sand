using Sand.Domain.Entities.Systems;
using Sand.Domain.Repositories;
using Sand.Domain.Repositories.Systems;
using Sand.Domain.Uow;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sand.Data.Repositories.Systems
{
    public class DicRepository : EfRepository<Dic>, IDicRepository
    {
        public DicRepository(IUnitOfWork uow) : base(uow)
        {
        }
    }
}
