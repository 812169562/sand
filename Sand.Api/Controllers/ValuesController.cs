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
    public class ValuesController : BaseApiController
    {

        public ValuesController()
        {
        }
        // GET api/values
        [HttpGet]
        [EnableCors("any")]
        public async Task<IEnumerable<string>> Get()
        {
            return await Task.FromResult(new string[] { "value1", "value2" });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "";
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
}
