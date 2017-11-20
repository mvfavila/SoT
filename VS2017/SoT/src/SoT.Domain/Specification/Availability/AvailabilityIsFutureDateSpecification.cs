using SoT.Domain.Interfaces.Specification;
using System;

namespace SoT.Domain.Specification.Availability
{
    class AvailabilityIsFutureDateSpecification : ISpecification<Entities.Availability>
    {
        public bool IsSatisfiedBy(Entities.Availability availability)
        {
            var yesterday = DateTime.Now.AddDays(-1);

            return availability.Date >= yesterday;
        }
    }
}
