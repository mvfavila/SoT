using SoT.Domain.Interfaces.Specification;
using System;

namespace SoT.Domain.Specification.City
{
    public class CityIsCountryNotNull : ISpecification<Entities.City>
    {
        public bool IsSatisfiedBy(Entities.City city)
        {
            return city.CountryId != Guid.Empty;
        }
    }
}
