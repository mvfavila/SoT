using SoT.Domain.Interfaces.Specification;

namespace SoT.Domain.Specification.Category
{
    public class CategoryIsNameNotNullAndNotEmpty : ISpecification<Entities.Category>
    {
        public bool IsSatisfiedBy(Entities.Category category)
        {
            return !string.IsNullOrEmpty(category.Name) && !string.IsNullOrWhiteSpace(category.Name);
        }
    }
}
