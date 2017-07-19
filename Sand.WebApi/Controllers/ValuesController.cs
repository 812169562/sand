using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sand.Web.Controllers;
using Microsoft.Extensions.Logging;
using Sand.Filter;
using Sand.Service;
using AspectCore.Abstractions;

namespace Sand.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IService _service;
        private readonly ILoggerFactory _loggerFactory;


        public ValuesController(IService service, ILoggerFactory loggerFactory)
        {
            _service = service;
            _loggerFactory = loggerFactory;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _service.CallBack("a"); ;
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
