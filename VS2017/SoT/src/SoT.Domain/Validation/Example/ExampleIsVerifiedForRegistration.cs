using SoT.Domain.Specification.Example;
using SoT.Domain.Validation.Base;

namespace SoT.Domain.Validation.Example
{
    public class ExampleIsVerifiedForRegistration : BaseSupervisor<Entities.Example.Example>
    {
        public ExampleIsVerifiedForRegistration()
        {
            var isRecentDate = new ExampleIsRecentDateSpecification();
            var hasSubExample = new ExampleHasSubExampleSpecification();
            var isActive = new ExampleIsActiveSpecification();

            base.AddRule("IsRecentDate", new Rule<Entities.Example.Example>(isRecentDate,
                "Example date has to be more recent than 2 years"));
            base.AddRule("HasSubExample", new Rule<Entities.Example.Example>(hasSubExample,
                "Example must have a SubExample"));
            base.AddRule("IsActive", new Rule<Entities.Example.Example>(isActive,
                "Example must be active to be registered"));
        }
    }
}
