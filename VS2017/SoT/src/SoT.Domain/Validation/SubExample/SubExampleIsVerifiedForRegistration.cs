using SoT.Domain.Specification.SubExample;
using SoT.Domain.Validation.Base;

namespace SoT.Domain.Validation.SubExample
{
    public class SubExampleIsVerifiedForRegistration : BaseSupervisor<Entities.Example.SubExample>
    {
        public SubExampleIsVerifiedForRegistration()
        {
            var hasPositiveCalculatedPropertyName = new SubExampleHasPositiveCalculatedPropertyNameSpecification();

            base.AddRule("HasPositiveCalculatedPropertyName", new Rule<Entities.Example.SubExample>(
                hasPositiveCalculatedPropertyName,
                "CalculatedPropertyName has to be a positive number"));
        }
    }
}
