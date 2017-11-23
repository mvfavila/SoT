using SoT.Domain.Interfaces.Specification;

namespace SoT.Domain.Specification.Adventure
{
    public class AdventureIsInsurenceMinimalAmountHigherThenZero : ISpecification<Entities.Adventure>
    {
        public bool IsSatisfiedBy(Entities.Adventure adventure)
        {
            if (!adventure.InsurenceMinimalAmount.HasValue)
                return true;

            return adventure.InsurenceMinimalAmount.Value > 0;
        }
    }
}
