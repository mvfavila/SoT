using SoT.Domain.Interfaces.Specification;
using System;

namespace SoT.Domain.Specification.Region
{
    public class RegionIsKeyNotNull : ISpecification<Entities.Region>
    {
        public bool IsSatisfiedBy(Entities.Region region)
        {
            return region.RegionId != Guid.Empty;
        }
    }
}
