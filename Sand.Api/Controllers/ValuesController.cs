using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sand.Filter;
using Sand.Service;
using Sand.Helpers;
using Sand.Maps;

namespace Sand.Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IBaseDataRepository _baseDataRepository;
        private readonly IService _service;

        public ValuesController(IService service, IBaseDataRepository baseDataRepository)
        {
            _baseDataRepository = baseDataRepository;
            _service = service;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var ff = _baseDataRepository.Retrieve();
            var list = ff.ToList();
            //foreach (var item in list)
            //{
            //    item.Id = Uuid.Next();
            //}
            var data = new BaseData();
            list.First().MapTo(data);
            data.Id= Uuid.Next();
            var mm = list.First();
            mm.LastUpdateName = "xx";
            _baseDataRepository.Update(list.First());
            _baseDataRepository.Create(data);
            _baseDataRepository.Test();
            _service.CallBack("111");
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
