using SoT.Domain.Interfaces.Specification;
using System;

namespace SoT.Domain.Specification.Adventure
{
    public class AdventureIsNameNotNullAndNotEmpty : ISpecification<Entities.Adventure>
    {
        public bool IsSatisfiedBy(Entities.Adventure adventure)
        {
            return !string.IsNullOrEmpty(adventure.Name) && !string.IsNullOrWhiteSpace(adventure.Name);
        }
    }
}
