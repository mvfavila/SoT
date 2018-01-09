using SoT.Application.Interfaces;
using SoT.Application.ViewModels;
using SoT.Domain.Interfaces.Services;
using SoT.Infra.Data.Context;
using System;
using SoT.Application.Validation;
using System.Collections.Generic;
using SoT.Domain.Entities;

namespace SoT.Application.AppServices
{
    public class AdventureAppService : BaseAppService<SoTContext>, IAdventureAppService
    {
        private readonly IAdventureService adventureService;

        public AdventureAppService(IAdventureService adventureService)
        {
            this.adventureService = adventureService;
        }

        public IEnumerable<AdventureAddressViewModel> GetAllByUser(Guid userId)
        {
            var adventures = adventureService.GetAllWithAddressById(userId);

            return Mapping.AdventureMapper.FromDomainToViewModel(adventures);
        }

        public AdventureAddressViewModel GetById(Guid adventureId, Guid userId)
        {
            var adventure = adventureService.GetWithAddressById(adventureId, userId);

            return Mapping.AdventureMapper.FromDomainToViewModel(adventure);
        }

        public ValidationAppResult Add(AdventureAddressViewModel adventureAddressViewModel)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            adventureService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
