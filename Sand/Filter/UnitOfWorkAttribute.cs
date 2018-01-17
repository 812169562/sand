using AspectCore.DynamicProxy;
using AspectCore.Injector;
using Sand.Domain.Uow;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Sand.Filter
{
    public class UowAttribute : AbstractInterceptorAttribute
    {
        //[FromContainer]
        private IUnitOfWork _uow;

        //[FromContainer]
        private ILog _log;
        public UowAttribute()
        {

        }
        public async override Task Invoke(AspectContext context, AspectDelegate next)
        {
            try
            {
                _uow = context.ServiceProvider.GetService<IUnitOfWork>();
                await next(context);
                _uow.Complete();
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException is DbUpdateException)
                {
                    var dbex = ex.InnerException as DbUpdateException;
                    _log = Log.Log.GetLog("UowAsync");
                    _log.Error(dbex.InnerException.Message);
                }
                else
                {
                    _log = Log.Log.GetLog("UowAsync");
                    _log.Error(ex.Message);
                }

                throw ex;
            }
        }
    }

    public class UowAsyncAttribute : AbstractInterceptorAttribute
    {
        private IUnitOfWork _uow;

        private ILog _log;

        public UowAsyncAttribute()
        {

        }
        public async override Task Invoke(AspectContext context, AspectDelegate next)
        {
            try
            {
                _uow = context.ServiceProvider.GetService<IUnitOfWork>();
                await next(context);
                await _uow.CompleteAsync();
            }
            catch (DbUpdateException ex)
            {
                _log = Log.Log.GetLog("UowAsync");
                _log.Error(ex.Message);
                throw ex;
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException is DbUpdateException)
                {
                    var dbex = ex.InnerException as DbUpdateException;
                    _log = Log.Log.GetLog("UowAsync");
                    _log.Error(dbex.InnerException.Message);
                }
                else
                {
                    _log = Log.Log.GetLog("UowAsync");
                    _log.Error(ex.Message);
                }
             
                throw ex;
            }
        }
    }
}
