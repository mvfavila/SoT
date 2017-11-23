using SoT.Domain.Interfaces.Specification;
using System;

namespace SoT.Domain.Specification.Country
{
    public class CountryIsKeyNotNull : ISpecification<Entities.Country>
    {
        public bool IsSatisfiedBy(Entities.Country country)
        {
            return country.CountryId != Guid.Empty;
        }
    }
}
