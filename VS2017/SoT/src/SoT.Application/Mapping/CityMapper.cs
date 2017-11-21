using SoT.Application.ViewModels;
using SoT.Domain.Entities;
using System.Collections.Generic;

namespace SoT.Application.Mapping
{
    public static class CityMapper
    {
        // CityViewModel

        internal static CityViewModel FromDomainToViewModel(
            City city)
        {
            return new CityViewModel
            {
                CityId = city.CityId,
                Name = city.Name,
                Active = city.Active,
                CountryId = city.CountryId
            };
        }

        internal static IEnumerable<CityViewModel> FromDomainToViewModel(
            IEnumerable<City> cities)
        {
            var viewModels = new List<CityViewModel>();
            foreach (var city in cities)
            {
                viewModels.Add(FromDomainToViewModel(city));
            }

            return viewModels;
        }
    }
}
