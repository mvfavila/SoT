using SoT.Domain.Interfaces.Specification;

namespace SoT.Domain.Specification.Example
{
    class ExampleIsActiveSpecification : ISpecification<Entities.Example.Example>
    {
        public bool IsSatisfiedBy(Entities.Example.Example example)
        {
            return example.Active;
        }
    }
}
