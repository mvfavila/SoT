using SoT.Domain.Interfaces.Specification;
using System;

namespace SoT.Domain.Specification.Category
{
    public class CategoryIsElementNotNull : ISpecification<Entities.Category>
    {
        public bool IsSatisfiedBy(Entities.Category category)
        {
            return category.ElementId != Guid.Empty;
        }
    }
}
