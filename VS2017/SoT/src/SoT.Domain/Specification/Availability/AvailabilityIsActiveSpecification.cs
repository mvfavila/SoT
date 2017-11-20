using SoT.Domain.Interfaces.Specification;

namespace SoT.Domain.Specification.Availability
{
    class AvailabilityIsActiveSpecification : ISpecification<Entities.Availability>
    {
        public bool IsSatisfiedBy(Entities.Availability availability)
        {
            return availability.Active;
        }
    }
}
