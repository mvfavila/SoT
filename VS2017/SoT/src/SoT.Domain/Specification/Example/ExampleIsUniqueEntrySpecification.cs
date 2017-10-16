using SoT.Domain.Interfaces.Repository;
using SoT.Domain.Interfaces.Specification;

namespace SoT.Domain.Specification.Example
{
    class ExampleIsUniqueEntrySpecification : ISpecification<Entities.Example.Example>
    {
        private readonly IExampleRepository exampleRepository;

        public ExampleIsUniqueEntrySpecification(IExampleRepository exampleRepository)
        {
            this.exampleRepository = exampleRepository;
        }

        public bool IsSatisfiedBy(Entities.Example.Example entity)
        {
            var example = exampleRepository.GetById(entity.ExampleId);
            var exampleDoesNotExists = example == null;
            return exampleDoesNotExists;
        }
    }
}
