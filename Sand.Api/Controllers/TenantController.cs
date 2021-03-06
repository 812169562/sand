﻿using Sand.Domain.Queries.Systems;
using Sand.Service.Dtos.Systems;
using Sand.Service.Contract.Systems;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sand.Result;
using Microsoft.AspNetCore.Cors;
using Sand.Helpers;

namespace Sand.Api.Controllers
{
    /// <summary>
    /// 租户控制器
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
        /// 初始化租户控制器
        /// </summary>
        /// <param name="service">租户服务</param>
        public TenantController(ITenantService service)
        {
            _tenantService = service;
        }

        /// <summary>
        /// 查询租户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get(TenantQuery tenantQuery)
        {
            return Success(await _tenantService.RetrieveAsync(tenantQuery));
        }

        /// <summary>
        /// 查询租户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Success(await _tenantService.RetrieveByIdAsync(id));
        }

        /// <summary>
        /// 请求租户分页信息
        /// </summary>
        /// <param name="tenantQuery">租户查询对象</param>
        /// <returns></returns>
        [HttpGet("page")]
        public async Task<IActionResult> Page(TenantQuery tenantQuery)
        {
            return Success(await _tenantService.PageAsync(tenantQuery));
        }

        /// <summary>
        /// 更新租户信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TenantDto tenant)
        {
            await _tenantService.UpdateAsync(tenant);
            return Success();
        }

        /// <summary>
        /// 新增租户信息
        /// </summary>
        /// <param name="tenant">租户信息</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]TenantDto tenant)
        {
            return Success(await _tenantService.CreateAsync(tenant));
        }

        /// <summary>
        /// 删除租户信息
        /// </summary>
        /// <param name="tenant">删除租户信息</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(List<TenantDto> tenant)
        {
            await _tenantService.DeleteAsync(tenant);
            return Success();
        }

        /// <summary>
        /// 停用租户信息
        /// </summary>
        /// <param name="tenant">租户信息</param>
        /// <param name="isEnable">是否可用</param>
        /// <returns></returns>
        [HttpPost("stop")]
        public async Task<IActionResult> Stop(List<TenantDto> tenant, bool isEnable = false)
        {
            await _tenantService.StopOrEnableAsync(tenant, isEnable);
            return Success();
        }
    }
}