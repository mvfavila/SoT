using SoT.Domain.Interfaces.Specification;

namespace SoT.Domain.Specification.Gender
{
    public class GenderIsValueNotNullAndNotEmpty : ISpecification<Entities.Gender>
    {
        public bool IsSatisfiedBy(Entities.Gender gender)
        {
            return !string.IsNullOrEmpty(gender.Value) && !string.IsNullOrWhiteSpace(gender.Value);
        }
    }
}
