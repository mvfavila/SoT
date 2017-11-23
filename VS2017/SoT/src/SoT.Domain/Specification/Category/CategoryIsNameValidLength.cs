using SoT.Domain.Interfaces.Specification;

namespace SoT.Domain.Specification.Category
{
    public class CategoryIsNameValidLength : ISpecification<Entities.Category>
    {
        const int NAME_MAX_LENGTH = 100;

        public bool IsSatisfiedBy(Entities.Category category)
        {
            if (category.Name == null)
                return true;

            return category.Name.Length <= NAME_MAX_LENGTH;
        }
    }
}
