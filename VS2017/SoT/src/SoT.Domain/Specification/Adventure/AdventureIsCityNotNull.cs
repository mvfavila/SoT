using SoT.Domain.Interfaces.Specification;
using System;

namespace SoT.Domain.Specification.Adventure
{
    public class AdventureIsCityNotNull : ISpecification<Entities.Adventure>
    {
        public bool IsSatisfiedBy(Entities.Adventure adventure)
        {
            return adventure.CityId != Guid.Empty;
        }
    }
}
