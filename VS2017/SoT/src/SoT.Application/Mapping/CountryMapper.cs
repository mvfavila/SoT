using SoT.Application.ViewModels;
using SoT.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SoT.Application.Mapping
{
    public static class CountryMapper
    {
        // CountryViewModel

        internal static CountryViewModel FromDomainToViewModel(
            Country country)
        {
            var cities = new List<CityViewModel>();
            if(country.Cities != null)
                cities = CityMapper.FromDomainToViewModel(country.Cities).ToList();

            return new CountryViewModel
            {
                CountryId = country.CountryId,
                Name = country.Name,
                Active = country.Active,
                RegionId = country.RegionId,
                Cities = cities
            };
        }

        internal static IEnumerable<CountryViewModel> FromDomainToViewModel(
            IEnumerable<Country> countries)
        {
            var viewModels = new List<CountryViewModel>();
            foreach (var country in countries)
            {
                viewModels.Add(FromDomainToViewModel(country));
            }

            return viewModels;
        }
    }
}
