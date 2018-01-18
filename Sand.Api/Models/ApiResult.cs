using Microsoft.AspNetCore.Mvc;
using Sand.Extensions;
using Sand.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sand.Api.Models
{
    /// <summary>
    /// 返回结果
    /// </summary>
    public class ApiResult : JsonResult
    {
        /// <summary>
        /// 状态码
        /// </summary>
        private readonly StateCode _code;
        /// <summary>
        /// 消息
        /// </summary>
        private readonly string _message;
        /// <summary>
        /// 数据
        /// </summary>
        private readonly dynamic _data;

        /// <summary>
        /// 初始化返回结果
        /// </summary>
        /// <param name="code">状态码</param>
        /// <param name="message">消息</param>
        /// <param name="data">数据</param>
        public ApiResult(StateCode code, string message, dynamic data = null) : base(null)
        {
            _code = code;
            _message = message;
            _data = data;
        }

        /// <summary>
        /// 执行结果
        /// </summary>
        public override Task ExecuteResultAsync(ActionContext context)
        {
            this.Value = new
            {
                Code = _code.Value(),
                Message = _message,
                Data = _data
            };
            return base.ExecuteResultAsync(context);
        }
    }
}
