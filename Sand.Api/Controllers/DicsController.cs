using Sand.Domain.Queries.Systems;
using Sand.Service.Dtos.Systems;
using Sand.Service.Contract.Systems;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sand.Result;

namespace Sand.Api.Controllers
{
    /// <summary>
    /// 字典表控制器
    /// </summary>
    [Route("api/[controller]")]
    public class DicsController : BaseApiController
    {
        /// <summary>
        /// 字典表服务
        /// </summary>
        private readonly IDicsService _dicsService;

        /// <summary>
        /// 初始化字典表控制器
        /// </summary>
        /// <param name="service">字典表服务</param>
        public DicsController(IDicsService service)
        {
            _dicsService = service;
        }

        /// <summary>
        /// 查询字典表信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get(DicsQuery dicsQuery)
        {
            return Success(await _dicsService.RetrieveAsync(dicsQuery));
        }

        /// <summary>
        /// 根据编号查询字典表信息
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Success(await _dicsService.RetrieveByIdAsync(id));
        }

        /// <summary>
        /// 请求字典表分页信息
        /// </summary>
        /// <param name="dicsQuery">字典表查询对象</param>
        /// <returns></returns>
        [HttpGet("page")]
        public async Task<IActionResult> Page(DicsQuery dicsQuery)
        {
            return Success(await _dicsService.PageAsync(dicsQuery));
        }

        /// <summary>
        /// 获取父节点数据
        /// </summary>
        /// <param name="patientId">父节点编号</param>
        /// <returns></returns>

        [HttpGet("patientnode")]
        public async Task<IActionResult> PatientNode(string patientId)
        {
            var dicsQuery = new DicsQuery();
            return Success(await _dicsService.RetrieveAsync(dicsQuery));
        }

        /// <summary>
        /// 更新字典表信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]DicsDto dics)
        {
            return Success(await _dicsService.CreateAsync(dics));
        }

        /// <summary>
        /// 新增字典表信息
        /// </summary>
        /// <param name="dics">字典表信息</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]DicsDto dics)
        {
            return Success(await _dicsService.CreateAsync(dics));
        }

        /// <summary>
        /// 删除字典表信息
        /// </summary>
        /// <param name="dics">字典表信息</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(List<DicsDto> dics)
        {
            await _dicsService.DeleteAsync(dics);
            return Success();
        }

        /// <summary>
        /// 停用字典表信息
        /// </summary>
        /// <param name="dics">字典表信息</param>
        /// <param name="isEnable">启用或者停用</param>
        /// <returns></returns>
        [HttpPost("stop")]
        public async Task<IActionResult> Stop(List<DicsDto> dics, bool isEnable = false)
        {
            await _dicsService.StopOrEnableAsync(dics, isEnable);
            return Success();
        }
    }
}