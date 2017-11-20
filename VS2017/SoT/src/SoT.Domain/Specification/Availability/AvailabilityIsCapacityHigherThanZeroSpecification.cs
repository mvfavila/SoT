using SoT.Domain.Interfaces.Specification;

namespace SoT.Domain.Specification.Availability
{
    class AvailabilityIsCapacityHigherThanZeroSpecification : ISpecification<Entities.Availability>
    {
        public bool IsSatisfiedBy(Entities.Availability availability)
        {
            return availability.Capacity > 0;
        }
    }
}
