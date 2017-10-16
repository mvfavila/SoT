using SoT.Domain.Interfaces.Specification;
using System;

namespace SoT.Domain.Specification.Example
{
    class ExampleIsRecentDateSpecification : ISpecification<Entities.Example.Example>
    {
        public bool IsSatisfiedBy(Entities.Example.Example example)
        {
            return DateTime.Now.Year - example.DatePropertyName.Year <= 2;
        }
    }
}
