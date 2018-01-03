using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspectCore.Injector;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sand.Context;
using Sand.Extension;
using Sand.Service.Contact.Systems;

namespace Sand.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Dic")]
    public class DicController : ApiController
    {
        private readonly IDicService _dicService;
        [FromContainer]
        public IUserContext UserContext { get; set; }
        public DicController(IDicService dicService)
        {
            _dicService = dicService;
        }
        public string Get() {
            _dicService.RetrieveById("08d551c2-753f-eb72-9fec-7b2434be8f34".ToGuid());
            return "";
        }
    }
}