using SoT.Application.Interfaces;
using SoT.Application.Mapping;
using SoT.Application.ViewModels;
using SoT.Domain.Interfaces.Services;
using SoT.Infra.Data.Context;
using System;
using System.Collections.Generic;

namespace SoT.Application.AppServices
{
    public class GenderAppService : BaseAppService<SoTContext>, IGenderAppService
    {
        private readonly IGenderService genderService;

        public GenderAppService(IGenderService genderService)
        {
            this.genderService = genderService;
        }

        public IEnumerable<GenderViewModel> GetAllActive()
        {
            return GenderMapper.FromDomainToViewModel(genderService.GetAllActive());
        }

        public void Dispose()
        {
            genderService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
