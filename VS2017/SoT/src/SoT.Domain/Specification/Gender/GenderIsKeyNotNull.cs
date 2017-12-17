using SoT.Domain.Interfaces.Specification;
using System;

namespace SoT.Domain.Specification.Gender
{
    public class GenderIsKeyNotNull : ISpecification<Entities.Gender>
    {
        public bool IsSatisfiedBy(Entities.Gender gender)
        {
            return gender.GenderId != Guid.Empty;
        }
    }
}
