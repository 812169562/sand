using AspectCore.DynamicProxy;
using AspectCore.Injector;
using Sand.Domain.Uow;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sand.Filter
{
    public class UnitOfWorkAttribute : AbstractInterceptorAttribute
    {
        [FromContainer]
        public IUnitOfWork Uow { get; set; }

        public async override Task Invoke(AspectContext context, AspectDelegate next)
        {
            try
            {
                Uow.Begin();
                await next(context);
                await Uow.CompleteAsync();
            }
            catch (Exception ex)
            {
                await Uow.RollBackAsync();
                //Log.Error(ex);
            }
            finally
            {
               //Uow.Complete();
            }
        }
    }
}
