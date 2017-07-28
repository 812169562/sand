using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sand.Domain.Repositories;

namespace Sand.Api
{
    public interface IBaseDataRepository : IRepository<BaseData, Guid>
    {
        string Test(); 
    }
}
