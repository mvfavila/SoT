using SoT.Application.ViewModels;
using SoT.Domain.Entities;

namespace SoT.Application.Mapping
{
    public static class CountryMapper
    {
        // CountryViewModel

        internal static CountryViewModel FromDomainToViewModel(
            Country country)
        {
            return new CountryViewModel
            {
                CountryId = country.CountryId,
                Name = country.Name,
                Active = country.Active
            };
        }
    }
}
