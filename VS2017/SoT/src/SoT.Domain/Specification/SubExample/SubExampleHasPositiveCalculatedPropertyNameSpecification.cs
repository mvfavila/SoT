using SoT.Domain.Interfaces.Specification;

namespace SoT.Domain.Specification.SubExample
{
    class SubExampleHasPositiveCalculatedPropertyNameSpecification : ISpecification<Entities.Example.SubExample>
    {
        public bool IsSatisfiedBy(Entities.Example.SubExample subExample)
        {
            return subExample.CalculatedPropertyName > 0;
        }
    }
}
