using System;
using SoT.Application.Interfaces;
using SoT.Application.Validation;
using SoT.Application.ViewModels;
using SoT.Domain.Interfaces.Services;
using SoT.Infra.Data.Context;

namespace SoT.Application.AppServices
{
    public class CountryAppService : BaseAppService<SoTContext>, ICountryAppService
    {
        private readonly ICountryService countryService;

        public CountryAppService(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        public ValidationAppResult Add(CountryViewModel countryViewModel)
        {
            throw new NotImplementedException();
        }

        public CountryViewModel GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public ValidationAppResult Update(CountryViewModel countryViewModel)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            countryService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
