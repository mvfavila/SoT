using SoT.Application.Interfaces;
using SoT.Domain.Interfaces.Services;
using SoT.Infra.Data.Context;
using System;

namespace SoT.Application.AppServices
{
    public class CityAppService : BaseAppService<SoTContext>, ICityAppService
    {
        private readonly ICityService cityService;

        public CityAppService(ICityService cityService)
        {
            this.cityService = cityService;
        }

        public void Dispose()
        {
            cityService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
