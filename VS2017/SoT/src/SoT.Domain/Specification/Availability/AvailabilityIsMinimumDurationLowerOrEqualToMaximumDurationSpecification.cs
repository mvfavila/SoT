using SoT.Domain.Interfaces.Specification;

namespace SoT.Domain.Specification.Availability
{
    class AvailabilityIsMinimumDurationLowerOrEqualToMaximumDurationSpecification
        : ISpecification<Entities.Availability>
    {
        public bool IsSatisfiedBy(Entities.Availability availability)
        {
            return availability.DurationMinimum <= availability.DurationMaximum;
        }
    }
}
