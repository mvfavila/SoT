using SoT.Domain.Interfaces.Specification;

namespace SoT.Domain.Specification.Adventure
{
    public class AdventureIsNameValidLength : ISpecification<Entities.Adventure>
    {
        const int NAME_MAX_LENGTH = 250;

        public bool IsSatisfiedBy(Entities.Adventure adventure)
        {
            if (adventure.Name == null)
                return true;

            return adventure.Name.Length <= NAME_MAX_LENGTH;
        }
    }
}
