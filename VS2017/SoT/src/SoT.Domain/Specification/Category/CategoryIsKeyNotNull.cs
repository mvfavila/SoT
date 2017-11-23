using SoT.Domain.Interfaces.Specification;
using System;

namespace SoT.Domain.Specification.Category
{
    public class CategoryIsKeyNotNull : ISpecification<Entities.Category>
    {
        public bool IsSatisfiedBy(Entities.Category category)
        {
            return category.CategoryId != Guid.Empty;
        }
    }
}
