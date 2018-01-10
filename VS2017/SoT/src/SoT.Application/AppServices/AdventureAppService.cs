using SoT.Application.Interfaces;
using SoT.Application.Validation;
using SoT.Application.ViewModels;
using SoT.Domain.Interfaces.Services;
using SoT.Infra.Data.Context;
using System;
using System.Collections.Generic;

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
            var adventure = Mapping.AdventureMapper.FromViewModelToDomain(adventureAddressViewModel);

            var address = Mapping.AddressMapper.FromViewModelToDomain(adventureAddressViewModel);

            adventure.AddAddress(address);

            var result = adventureService.Add(adventure);

            // TODO: log should be added here informing that the adventure was added
            // TODO: check if it was a valid insertion
            if(result.IsValid)
                Commit();

            return FromDomainToApplicationResult(result);
        }

        public void Dispose()
        {
            adventureService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
