﻿using SoT.Application.Interfaces;
using SoT.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace SoT.Services.WebAPI.Controllers
{
    public class ExamplesController : ApiController
    {
        private readonly IExampleAppService exampleAppService;

        public ExamplesController(IExampleAppService exampleAppService)
        {
            this.exampleAppService = exampleAppService;
        }

        // GET: api/Examples
        public IEnumerable<ExampleViewModel> Get()
        {
            return exampleAppService.GetAll();
        }

        // GET: api/Examples/5
        public ExampleViewModel Get(Guid id)
        {
            return exampleAppService.GetById(id);
        }

        // POST: api/Examples
        [HttpPost]
        public void Post([FromBody]ExampleSubExampleViewModel exampleSubExampleViewModel)
        {
            exampleAppService.Add(exampleSubExampleViewModel);
        }

        // PUT: api/Examples/5
        [HttpPut]
        public void Put([FromBody]ExampleViewModel exampleViewModel)
        {
            exampleAppService.Update(exampleViewModel);
        }

        // DELETE: api/Examples/5
        public void Delete(Guid id)
        {
            exampleAppService.Remove(id);
        }
    }
}
