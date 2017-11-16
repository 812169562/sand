using AspectCore.DynamicProxy;
using AspectCore.Injector;
using Sand.Domain.Uow;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
namespace Sand.Filter
{
    public class UowAttribute : AbstractInterceptorAttribute
    {
        //[FromContainer]
        private IUnitOfWork _uow;

        [FromContainer]
        public ILog Log { get; set; }

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
                _uow.RollBack();
                Log.Error(ex.Message);
            }
            finally
            {
            }
        }
    }

    public class UowAsyncAttribute : AbstractInterceptorAttribute
    {
        public IUnitOfWork _uow { get; set; }
        [FromContainer]
        public ILog Log { get; set; }
        public async override Task Invoke(AspectContext context, AspectDelegate next)
        {
            try
            {
                _uow = context.ServiceProvider.GetService<IUnitOfWork>();
                await next(context);
                await _uow.CompleteAsync();
            }
            catch (System.Exception ex)
            {
                await _uow.RollBackAsync();
                Log.Error(ex.Message);
            }
            finally
            {
                //Uow.Complete();
            }
        }
    }
}
