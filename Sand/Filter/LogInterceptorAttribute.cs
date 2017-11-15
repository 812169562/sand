using System;
using System.Threading.Tasks;
using Sand.Dependency;
using NLog;
using AspectCore.DynamicProxy;
using AspectCore.Injector;
using Sand.Context;

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

    /// <summary>
    /// 日志接口
    /// </summary>
    public interface ILog : IDependency
    {
        /// <summary>
        /// 调试级别是否启用
        /// </summary>
        bool IsDebugEnabled { get; }
        /// <summary>
        /// 跟踪级别是否启用
        /// </summary>
        bool IsTraceEnabled { get; }
        /// <summary>
        /// 跟踪
        /// </summary>
        void Trace();
        /// <summary>
        /// 跟踪
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        void Trace(string message, params object[] args);
        /// <summary>
        /// 调试
        /// </summary>
        void Debug();
        /// <summary>
        /// 调试
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        void Debug(string message, params object[] args);
        /// <summary>
        /// 信息
        /// </summary>
        void Info();
        /// <summary>
        /// 信息
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        void Info(string message, params object[] args);
        /// <summary>
        /// 警告
        /// </summary>
        void Warn();
        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        void Warn(string message, params object[] args);
        /// <summary>
        /// 错误
        /// </summary>
        void Error();
        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        void Error(string message, params object[] args);
        /// <summary>
        /// 致命错误
        /// </summary>
        void Fatal();
        /// <summary>
        /// 致命错误
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        void Fatal(string message, params object[] args);
    }
    /// <summary>
    /// 日志实现
    /// </summary>
    public class Log : ILog
    {
        public bool IsDebugEnabled => throw new NotImplementedException();

        public bool IsTraceEnabled => throw new NotImplementedException();
        public Logger Logger { get; }
        public Log()
        {
            Logger = LogManager.GetLogger("ILog");
        }

        public void Debug()
        {
            throw new NotImplementedException();
        }

        public void Warn()
        {
            throw new NotImplementedException();
        }

        public void Error()
        {
            throw new NotImplementedException();
        }

        public void Trace()
        {
            throw new NotImplementedException();
        }

        public void Trace(string message, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Debug(string message, params object[] args)
        {
            Logger.Debug(message);
        }

        public void Info()
        {
            throw new NotImplementedException();
        }

        public void Info(string message, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Warn(string message, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Error(string message, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Fatal()
        {
            throw new NotImplementedException();
        }

        public void Fatal(string message, params object[] args)
        {
            throw new NotImplementedException();
        }
    }
}
