using AspectCore.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using AspectCore.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Sand.Dependency;
using Microsoft.Extensions.Logging;
using NLog;

namespace Sand.Filter
{
    /// <summary>
    /// 日志aop
    /// </summary>
    public class LogInterceptorAttribute : InterceptorAttribute
    {
        [Inject]
        public ILog Log { get; set; }
        public async override Task Invoke(AspectContext context, AspectDelegate next)
        {
            var beforeTime = DateTime.UtcNow;
            TimeSpan beforeTs = new TimeSpan(beforeTime.Ticks);
            try
            {
                Log.Logger.LogDebug("before：" + beforeTime + "*" + context.Target.ImplementationType.Name + "*" + context.Target.ImplementationMethod.Name);
                await next(context);
            }
            catch (Exception ex)
            {
                Log.Logger.LogError("error：" + beforeTime + "*" + context.Target.ImplementationType.Name + "*" + context.Target.ImplementationMethod.Name);
                throw;
            }
            finally
            {
                var afterTime = DateTime.UtcNow;
                TimeSpan afterTs = new TimeSpan(afterTime.Ticks);
                Log.Logger.LogDebug("用时：" + (afterTs - beforeTs).Milliseconds + "毫秒");
                Log.Logger.LogDebug("after：" + afterTime + "*" + context.Target.ImplementationType.Name + "*" + context.Target.ImplementationMethod.Name);
            }
        }
    }

    /// <summary>
    /// 日志接口
    /// </summary>
    public interface ILog : IDependency
    {
        /// <summary>
        /// core日志
        /// </summary>
        ILogger<Log> Logger { get; set; }
    }
    /// <summary>
    /// 日志实现
    /// </summary>
    public class Log : ILog
    {
        /// <summary>
        /// core日志
        /// </summary>
        public ILogger<Log> Logger { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        /// <param name="logger">日志</param>
        public Log(ILogger<Log> logger)
        {
            Logger = logger;
        }
    }
}
