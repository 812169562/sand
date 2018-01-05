using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspectCore.Injector;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sand.Context;
using Sand.Domain.Queries.Systems;
using Sand.Extension;
using Sand.Service.Contact.Systems;
using Sand.Service.Dtos.Systems;

namespace Sand.Api.Controllers
{
    /// <summary>
    /// 数据字典
    /// </summary>
    [Route("api/[controller]")]
    public class DicController : ApiController
    {
        /// <summary>
        /// 数据字典服务
        /// </summary>
        private readonly IDicService _dicService;
        /// <summary>
        /// 用户上下文
        /// </summary>
        [FromContainer]
        public IUserContext UserContext { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="dicService">数据字典服务</param>
        public DicController(IDicService dicService)
        {
            _dicService = dicService;
        }
        /// <summary>
        /// 获取字典信息
        /// </summary>
        /// <returns>字典信息</returns>
        [HttpGet]
        public async Task<IList<DicDto>> Get(DicQuery query) {
            var task = await _dicService.RetrieveAsync(query);
            return task;
        }
    }
}