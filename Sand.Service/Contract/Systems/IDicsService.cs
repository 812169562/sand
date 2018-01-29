using Sand.Domain.Queries.Systems;
using Sand.Domain.Entities.Systems;
using Sand.Service.Dtos.Systems;
using System;

namespace Sand.Service.Contract.Systems {
    /// <summary>
    /// 字典表服务
    /// </summary>
    public interface IDicsService : IService<DicsDto, DicsQuery,Dics> {
    }
}