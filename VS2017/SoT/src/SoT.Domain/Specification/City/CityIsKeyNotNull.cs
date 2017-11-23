using SoT.Domain.Interfaces.Specification;
using System;

namespace SoT.Domain.Specification.City
{
    public class CityIsKeyNotNull : ISpecification<Entities.City>
    {
        public bool IsSatisfiedBy(Entities.City city)
        {
            return city.CityId!= Guid.Empty;
        }
    }
}
