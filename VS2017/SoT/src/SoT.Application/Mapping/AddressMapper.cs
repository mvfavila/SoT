using SoT.Application.ViewModels;
using SoT.Domain.Entities;

namespace SoT.Application.Mapping
{
    public static class AddressMapper
    {
        // AdventureAddressViewModel

        internal static Address FromViewModelToDomain(AdventureAddressViewModel adventureAddressViewModel)
        {
            return Address.FactoryAdd(
                adventureAddressViewModel.Street01,
                adventureAddressViewModel.Complement,
                adventureAddressViewModel.Postcode,
                adventureAddressViewModel.AdventureId
                );
        }
    }
}
