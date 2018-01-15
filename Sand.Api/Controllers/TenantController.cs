using AspectCore.Injector;
using Microsoft.AspNetCore.Mvc;
using Sand.Context;
using Sand.Service.Contact.Systems;
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
    public class TenantController : BaseApiController
    {
        /// <summary>
        /// 租户服务
        /// </summary>
        private readonly ITenantService _tenantService;
        /// <summary>
        /// 用户上下文
        /// </summary>
        [FromContainer]
        public IUserContext UserContext { get; set; }
        /// <summary>
        /// 租户Api
        /// </summary>
        /// <param name="tenantService"></param>
        public TenantController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        [HttpGet()]
        public string Get()
        {
            return "";
        }
    }
}
