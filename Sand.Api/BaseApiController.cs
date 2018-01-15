using AspectCore.Injector;
using Microsoft.AspNetCore.Mvc;
using Sand.Api.Controllers;
using Sand.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sand.Api
{
    public class BaseApiController : Controller
    {
        public const string ApiVersion = "api/[controller]";
        [FromContainer]
        public IUserContext UserContext { get; set; }

        static BaseApiController()
        {
        }
        public BaseApiController()
        {

        }
    }
}
