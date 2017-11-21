using System;
using SoT.Application.Interfaces;
using SoT.Application.Validation;
using SoT.Application.ViewModels;
using SoT.Domain.Interfaces.Services;
using SoT.Infra.Data.Context;
using SoT.Application.Mapping;
using System.Collections.Generic;

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
            return CountryMapper.FromDomainToViewModel(countryService.GetById(id));
        }

        public IEnumerable<CountryViewModel> GetAll()
        {
            return CountryMapper.FromDomainToViewModel(countryService.GetAll());
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
