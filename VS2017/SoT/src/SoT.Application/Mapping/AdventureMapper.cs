using SoT.Application.ViewModels;
using SoT.Domain.Entities;

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
    }
}
