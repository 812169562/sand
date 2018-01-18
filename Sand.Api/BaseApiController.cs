using AspectCore.Injector;
using Autofac;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Sand.Api.Controllers;
using Sand.Api.Filters;
using Sand.Api.Models;
using Sand.Context;
using Sand.DI;
using Sand.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sand.Api
{
    /// <summary>
    /// api基类
    /// </summary>
    [Route(ApiVersion)]
    [ExceptionHandler]
    public class BaseApiController : Controller
    {
        /// <summary>
        /// api版本号
        /// </summary>
        public const string ApiVersion = "api/[controller]";

        /// <summary>
        /// 用户信息
        /// </summary>
        public IUserContext UserContext { get; set; }

        /// <summary>
        /// api基类
        /// </summary>
        public BaseApiController()
        {
            UserContext=DefaultIocConfig.Container.Resolve<IUserContext>();
        }

        /// <summary>
        /// 返回成功消息
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        protected virtual IActionResult Success(dynamic data = null, string message = null)
        {
            if (message == null)
                message = "成功";
            return new ApiResult(StateCode.Ok, message, data);
        }

        /// <summary>
        /// 返回失败消息
        /// </summary>
        /// <param name="message">消息</param>
        protected IActionResult Fail(string message)
        {
            return new ApiResult(StateCode.Fail, message);
        }
    }
}
