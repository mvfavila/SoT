using SoT.Domain.Interfaces.Specification;

namespace SoT.Domain.Specification.Adventure
{
    public class AdventureIsInsurenceMinimalAmountLowerThanMaxValue : ISpecification<Entities.Adventure>
    {
        const decimal INSURENCE_MINIMAL_AMOUNT_MAX_VALUE = 9999999.99M;

        public bool IsSatisfiedBy(Entities.Adventure adventure)
        {
            if (!adventure.InsurenceMinimalAmount.HasValue)
                return true;

            return adventure.InsurenceMinimalAmount.Value <= INSURENCE_MINIMAL_AMOUNT_MAX_VALUE;
        }
    }
}
