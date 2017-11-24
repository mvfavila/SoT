using SoT.Domain.Interfaces.Specification;

namespace SoT.Domain.Specification.Region
{
    public class RegionIsNameValidLength : ISpecification<Entities.Region>
    {
        const int NAME_MAX_LENGTH = 100;

        public bool IsSatisfiedBy(Entities.Region region)
        {
            if (region.Name == null)
                return true;

            return region.Name.Length <= NAME_MAX_LENGTH;
        }
    }
}
