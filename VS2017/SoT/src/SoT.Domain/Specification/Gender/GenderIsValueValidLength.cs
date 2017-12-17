using SoT.Domain.Interfaces.Specification;

namespace SoT.Domain.Specification.Gender
{
    public class GenderIsValueValidLength : ISpecification<Entities.Gender>
    {
        const int VALUE_MAX_LENGTH = 30;

        public bool IsSatisfiedBy(Entities.Gender gender)
        {
            if (gender.Value == null)
                return true;

            return gender.Value.Length <= VALUE_MAX_LENGTH;
        }
    }
}
