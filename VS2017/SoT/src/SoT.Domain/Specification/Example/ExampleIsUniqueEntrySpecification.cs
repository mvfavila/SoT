using SoT.Domain.Interfaces.Repository.ReadOnly;
using SoT.Domain.Interfaces.Specification;

namespace SoT.Domain.Specification.Example
{
    class ExampleIsUniqueEntrySpecification : ISpecification<Entities.Example.Example>
    {
        private readonly IExampleReadOnlyRepository exampleRepository;

        public ExampleIsUniqueEntrySpecification(IExampleReadOnlyRepository exampleRepository)
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
