using SoT.Application.Interfaces;
using SoT.Domain.Interfaces.Services;
using SoT.Infra.Data.Context;
using System;
using SoT.Application.ViewModels;
using System.Collections.Generic;
using SoT.Application.Mapping;

namespace SoT.Application.AppServices
{
    public class CityAppService : BaseAppService<SoTContext>, ICityAppService
    {
        private readonly ICityService cityService;

        public CityAppService(ICityService cityService)
        {
            this.cityService = cityService;
        }

        public IEnumerable<CityViewModel> GetAll()
        {
            return CityMapper.FromDomainToViewModel(cityService.GetAll());
        }

        public CityViewModel GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CityViewModel> GetActiveByCountry(Guid countryId)
        {
            return CityMapper.FromDomainToViewModel(cityService.GetActiveByCountry(countryId));
        }

        public void Dispose()
        {
            cityService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
