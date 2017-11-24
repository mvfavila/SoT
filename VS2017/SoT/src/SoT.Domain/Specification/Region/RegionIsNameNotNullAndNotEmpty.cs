using SoT.Domain.Interfaces.Specification;

namespace SoT.Domain.Specification.Region
{
    public class RegionIsNameNotNullAndNotEmpty : ISpecification<Entities.Region>
    {
        public bool IsSatisfiedBy(Entities.Region region)
        {
            return !string.IsNullOrEmpty(region.Name) && !string.IsNullOrWhiteSpace(region.Name);
        }
    }
}
