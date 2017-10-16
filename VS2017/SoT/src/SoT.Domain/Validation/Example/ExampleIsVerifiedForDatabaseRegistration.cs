using SoT.Domain.Interfaces.Repository;
using SoT.Domain.Specification.Example;
using SoT.Domain.Validation.Base;

namespace SoT.Domain.Validation.Example
{
    public class ExampleIsVerifiedForDatabaseRegistration : BaseSupervisor<Entities.Example.Example>
    {
        private readonly IExampleRepository exampleRepository;

        public ExampleIsVerifiedForDatabaseRegistration(IExampleRepository exampleRepository)
        {
            this.exampleRepository = exampleRepository;
            
            var isUniqueEntry = new ExampleIsUniqueEntrySpecification(exampleRepository);
            
            base.AddRule("IsUniqueEntry", new Rule<Entities.Example.Example>(isUniqueEntry,
                "Example is already registered"));
        }
    }
}
