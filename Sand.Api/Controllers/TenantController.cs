using AspectCore.Injector;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Sand.Context;
using Sand.Domain.Entities.Systems;
using Sand.Result;
using Sand.Service.Contact.Systems;
using Sand.Service.Dtos.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sand.Api.Controllers
{
    /// <summary>
    /// 租户api
    /// </summary>
    [Route("api/[controller]")]
    [EnableCors("any")]
    public class TenantController : BaseApiController
    {
        /// <summary>
        /// 租户服务
        /// </summary>
        private readonly ITenantService _tenantService;
        /// <summary>
        /// 租户Api
        /// </summary>
        /// <param name="tenantService"></param>
        public TenantController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        /// <summary>
        /// 查询租户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IList<TenantDto>> Get(TenantQuery query)
        {
            return await _tenantService.RetrieveAsync(query);
        }


        /// <summary>
        /// 请求租户分页信息
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns></returns>
        [HttpGet("page", Name = "page")]
        public async Task<Paged<TenantDto>> Page(TenantQuery query)
        {
            return await _tenantService.PageAsync(query);
        }

        /// <summary>
        /// 更新租户信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<TenantDto> Post([FromBody]TenantDto tenant)
        {
            return await _tenantService.CreateAsync(tenant);
        }
        /// <summary>
        /// 新增租户信息
        /// </summary>
        /// <param name="tenant">租户信息</param>
        [HttpPut]
        public async Task<IActionResult> Put(TenantDto tenant)
        {
            return Success(await _tenantService.CreateAsync(tenant));
        }
    }
}
