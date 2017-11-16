using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sand.Domain.Repositories;
using Sand.Domain.Uow;
using Microsoft.EntityFrameworkCore;

namespace Sand.Api
{
    public class BaseDataRepository : EfRepository<BaseData, Guid>, IBaseDataRepository
    {
        public BaseDataRepository(IUnitOfWork uow) : base(uow)
        {
        }

        public string Test()
        {
            return "autofac";
        }
    }
}
