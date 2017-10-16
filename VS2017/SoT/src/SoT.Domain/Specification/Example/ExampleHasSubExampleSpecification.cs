using SoT.Domain.Interfaces.Specification;
using System.Linq;

namespace SoT.Domain.Specification.Example
{
    class ExampleHasSubExampleSpecification : ISpecification<Entities.Example.Example>
    {
        public bool IsSatisfiedBy(Entities.Example.Example example)
        {
            return example.SubExamples != null && example.SubExamples.Any();
        }
    }
}
