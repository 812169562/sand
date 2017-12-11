using System;
using System.Threading.Tasks;
using Sand.Dependency;
using NLog;
using AspectCore.DynamicProxy;
using AspectCore.Injector;
using Sand.Context;
using Microsoft.Extensions.Logging;

namespace Sand.Filter
{
    /// <summary>
    /// 日志aop
    /// </summary>
    public class LogInterceptorAttribute : AbstractInterceptorAttribute
    {
        [FromContainer]
        public IUserContext UserContext { get; set; }

        [FromContainer]
        public ILog Log { get; set; }
        public async override Task Invoke(AspectContext context, AspectDelegate next)
        {
            var beforeTime = DateTime.UtcNow;
            TimeSpan beforeTs = new TimeSpan(beforeTime.Ticks);
            try
            {
                Log.Debug("before：");
                await next(context);
            }
            catch (Exception ex)
            {
                Log.Error("error：" + beforeTime + "*" + context.ImplementationMethod.Name + "*" + context.ImplementationMethod.Name);
                throw;
            }
            finally
            {
                var afterTime = DateTime.UtcNow;
                TimeSpan afterTs = new TimeSpan(afterTime.Ticks);
                Log.Debug("用时：" + (afterTs - beforeTs).Milliseconds + "毫秒");
                Log.Debug("after：" + afterTime + "*" + context.ImplementationMethod.Name + "*" + context.ImplementationMethod.Name);
            }
        }
    }
}
