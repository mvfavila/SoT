using SoT.Domain.Interfaces.Specification;
using System;

namespace SoT.Domain.Specification.Country
{
    public class CountryIsRegionNotNull : ISpecification<Entities.Country>
    {
        public bool IsSatisfiedBy(Entities.Country country)
        {
            return country.RegionId != Guid.Empty;
        }
    }
}
