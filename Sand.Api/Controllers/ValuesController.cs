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
using System.Text;
using AspectCore.Injector;
using Microsoft.AspNetCore.Cors;

namespace Sand.Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : BaseApiController
    {
        private readonly IBaseDataRepository _baseDataRepository;

        public ValuesController(IBaseDataRepository baseDataRepository)
        {
            _baseDataRepository = baseDataRepository;
        }
        // GET api/values
        [HttpGet]
        [EnableCors("any")]
        public async Task<IEnumerable<string>> Get()
        {

            var basedata = new BaseData()
            {
                Code = "1",
                TenantId = Guid.NewGuid(),
                CreateTime = DateTime.Now,
                CreateId = Guid.NewGuid().ToString(),
                CreateName = "1",
                LastUpdateTime = DateTime.Now,
                LastUpdateId = "1",
                LastUpdateName = "1",
                IsEnable = true,
                Name = "1",
                PinYin = "1",
                FullPinYin = "1",
            };
            //_baseDataRepository.Test();
           // _baseDataRepository.Create(basedata);
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
}
