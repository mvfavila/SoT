using SoT.Domain.Specification.Availability;
using SoT.Domain.Validation.Base;

namespace SoT.Domain.Validation.Availability
{
    public class AvailabilityIsVerifiedForRegistration : BaseSupervisor<Entities.Availability>
    {
        public AvailabilityIsVerifiedForRegistration()
        {
            var isActive = new AvailabilityIsActiveSpecification();
            var isFutureDate = new AvailabilityIsFutureDateSpecification();
            var isMinimumDurationLowerOrEqualToMaximumDuration =
                new AvailabilityIsMinimumDurationLowerOrEqualToMaximumDurationSpecification();
            var isCapacityHigherThanZero = new AvailabilityIsCapacityHigherThanZeroSpecification();

            base.AddRule("IsActive", new Rule<Entities.Availability>(isActive,
                "Availability has to be Active"));
            base.AddRule("IsFutureDate", new Rule<Entities.Availability>(isFutureDate,
                "Availability Date has to be a Future date"));
            base.AddRule("IsMinimumDurationLowerOrEqualToMaximumDuration", new Rule<Entities.Availability>(
                isMinimumDurationLowerOrEqualToMaximumDuration,
                "Availability maximum duration has to be higher of equal to minimum duration"));
            base.AddRule("IsCapacityHigherThanZero", new Rule<Entities.Availability>(isCapacityHigherThanZero,
                "Availability capacity has to be higher than 0(zero)"));
        }
    }
}
