using Exceptionless.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using Sand.Api.Models;
using Sand.Exceptions;
using Sand.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sand.Api.Filters
{
    /// <summary>
    /// 异常处理过滤器
    /// </summary>
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// 异常处理
        /// </summary>
        public override void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            context.HttpContext.Response.StatusCode = 200;
            var message = "";
            if (context.Exception.InnerException is Warning)
            {
                var exception = context.Exception.InnerException as Warning;
                message = exception.Messages;
            }
            else
            {
                message = context.Exception.GetMessage();
            }
            context.Result = new ApiResult(StateCode.Fail, message);
        }
    }
}
