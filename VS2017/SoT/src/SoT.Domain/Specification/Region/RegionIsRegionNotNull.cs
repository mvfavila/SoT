using SoT.Domain.Interfaces.Specification;
using System;

namespace SoT.Domain.Specification.Region
{
    public class RegionIsRegionNotNull : ISpecification<Entities.Region>
    {
        public bool IsSatisfiedBy(Entities.Region region)
        {
            return region.ContinentId != Guid.Empty;
        }
    }
}
