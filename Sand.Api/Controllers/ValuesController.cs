using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sand.Filter;
using Sand.Service;
using Sand.Helpers;
using Sand.Maps;
using Sand.Context;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;
using AspectCore.Injector;
using Microsoft.AspNetCore.Cors;

namespace Sand.Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : ApiController
    {
        //private readonly IBaseDataRepository _baseDataRepository;
        //[FromContainer]
        //public IUserContext UserContext { get; set; }
        public ValuesController()
        {
        }
        // GET api/values
        [HttpGet]
        [EnableCors("any")]
        public async Task<IEnumerable<string>> Get()
        {
            try
            {
                //var basedata = new BaseData()
                //{
                //    Code = "1",
                //    TenantId = Guid.NewGuid(),
                //    CreateTime = DateTime.Now,
                //    CreateId = Guid.NewGuid().ToString(),
                //    CreateName = "1",
                //    LastUpdateTime = DateTime.Now,
                //    LastUpdateId = "1",
                //    LastUpdateName = "1",
                //    IsEnable = true,
                //    Name = "1",
                //    PinYin = "1",
                //    FullPinYin = "1",
                //    Version = Encoding.UTF8.GetBytes(Guid.NewGuid().ToString())
                //};
                //_baseDataRepository.Test();
                //_baseDataRepository.Create(basedata);
                return await Task.FromResult(new string[] { "value1", "value2" });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "1";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class ApiController : Controller
    {
        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            return base.OnActionExecutionAsync(context, next);
        }
    }
}
