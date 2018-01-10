using SoT.Application.ViewModels;
using SoT.Domain.Entities;
using System.Collections.Generic;
using System;

namespace SoT.Application.Mapping
{
    public static class AdventureMapper
    {
        //AdventureAddressViewModel

        internal static AdventureAddressViewModel FromDomainToViewModel(Adventure adventure)
        {
            return new AdventureAddressViewModel
            {
                AdventureId = adventure.AdventureId,
                Name = adventure.Name,
                CategoryId = adventure.CategoryId,
                CityId = adventure.CityId,
                InsurenceMinimalAmount = adventure.InsurenceMinimalAmount,
                ProviderId = adventure.ProviderId,
                Active = adventure.Active,
                AddressId = adventure.AddressId,
                Street01 = adventure.Address.Street01,
                Complement = adventure.Address.Complement,
                Postcode = adventure.Address.Postcode
            };
        }

        internal static IEnumerable<AdventureAddressViewModel> FromDomainToViewModel(IEnumerable<Adventure> adventures)
        {
            var viewModels = new List<AdventureAddressViewModel>();

            foreach (var adventure in adventures)
            {
                viewModels.Add(FromDomainToViewModel(adventure));
            }

            return viewModels;
        }

        internal static Adventure FromViewModelToDomain(AdventureAddressViewModel adventureAddressViewModel)
        {
            return Adventure.FactoryAdd(
                adventureAddressViewModel.Name,
                adventureAddressViewModel.CategoryId,
                adventureAddressViewModel.CityId,
                adventureAddressViewModel.AddressId,
                adventureAddressViewModel.InsurenceMinimalAmount,
                adventureAddressViewModel.ProviderId
                );
        }
    }
}
