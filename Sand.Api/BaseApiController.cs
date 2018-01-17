using AspectCore.Injector;
using Autofac;
using Microsoft.AspNetCore.Mvc;
using Sand.Api.Controllers;
using Sand.Context;
using Sand.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sand.Api
{
    public class BaseApiController : Controller
    {
        public const string ApiVersion = "api/[controller]";
        public IUserContext UserContext { get; set; }

        static BaseApiController()
        {
        }
        public BaseApiController()
        {
            UserContext=DefaultIocConfig.Container.Resolve<IUserContext>();
        }
    }
}
