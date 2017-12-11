using SoT.Application.Interfaces;
using SoT.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace SoT.Services.WebAPI.Controllers
{
    public class CountryController : ApiController
    {
        private readonly ICountryAppService countryAppService;

        public CountryController(ICountryAppService countryAppService)
        {
            this.countryAppService = countryAppService;
        }

        // GET: api/Country
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Country/7416d8bc-a633-470e-a9ab-9c446b717058
        public CountryViewModel Get(Guid id)
        {
            var country = countryAppService.GetById(id);
            return country;
        }

        // POST: api/Country
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Country/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Country/5
        public void Delete(int id)
        {
        }
    }
}
