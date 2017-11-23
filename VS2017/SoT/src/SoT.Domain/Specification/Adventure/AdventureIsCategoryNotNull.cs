using SoT.Domain.Interfaces.Specification;
using System;

namespace SoT.Domain.Specification.Adventure
{
    public class AdventureIsCategoryNotNull : ISpecification<Entities.Adventure>
    {
        public bool IsSatisfiedBy(Entities.Adventure adventure)
        {
            return adventure.CategoryId != Guid.Empty;
        }
    }
}
