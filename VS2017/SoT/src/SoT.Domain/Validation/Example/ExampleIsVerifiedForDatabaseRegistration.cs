using SoT.Domain.Interfaces.Repository.ReadOnly;
using SoT.Domain.Specification.Example;
using SoT.Domain.Validation.Base;

namespace SoT.Domain.Validation.Example
{
    public class ExampleIsVerifiedForDatabaseRegistration : BaseSupervisor<Entities.Example.Example>
    {
        private readonly IExampleReadOnlyRepository exampleReadOnlyRepository;

        public ExampleIsVerifiedForDatabaseRegistration(IExampleReadOnlyRepository exampleReadOnlyRepository)
        {
            this.exampleReadOnlyRepository = exampleReadOnlyRepository;

            var isUniqueEntry = new ExampleIsUniqueEntrySpecification(exampleReadOnlyRepository);

            base.AddRule("IsUniqueEntry", new Rule<Entities.Example.Example>(isUniqueEntry,
                "Example is already registered"));
        }
    }
}
