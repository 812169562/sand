using Sand.Dependency;
using Sand.Filter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sand.Service
{
    [LogInterceptor]
    public interface IService: IDependency
    {
        string CallBack(string m);
    }

    public class BaseService : IService
    {
        public string CallBack(string m)
        {
            return m;
        }
    }
}
