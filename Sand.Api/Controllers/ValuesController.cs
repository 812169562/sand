﻿using System;
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

namespace Sand.Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IBaseDataRepository _baseDataRepository;
        public IUserContext UserContext { get; set; }
        public ValuesController(IBaseDataRepository baseDataRepository)
        {
            _baseDataRepository = baseDataRepository;
        }
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            var ff = _baseDataRepository.Retrieve();
            //var list = ff.ToList();
            ////foreach (var item in list)
            ////{
            ////    item.Id = Uuid.Next();
            ////}
            //var data = new BaseData();
            //list.First().MapTo(data);
            //data.Id = Uuid.Next();
            //data.LastUpdateTime = DateTime.UtcNow;
            //var mm = list.First();
            //await _baseDataRepository.CreateAsync(data);
            //mm.LastUpdateName = DateTime.Now.ToString();
            //await _baseDataRepository.UpdateAsync(list.First());
            //_baseDataRepository.Test();
            return await Task.FromResult(new string[] { "value1", "value2" });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return _baseDataRepository.Test();
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

    public class ApiController: Controller
    {
        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            return base.OnActionExecutionAsync(context, next);
        }
    }
}
