using SoT.Domain.Interfaces.Specification;
using System;

namespace SoT.Domain.Specification.Adventure
{
    public class AdventureisInsurenceMinimalAmountTwoDecimalPlaces : ISpecification<Entities.Adventure>
    {
        const decimal INSURENCE_MINIMAL_AMOUNT_MAX_VALUE = 9999999.99M;

        public bool IsSatisfiedBy(Entities.Adventure adventure)
        {
            if (!adventure.InsurenceMinimalAmount.HasValue)
                return true;

            var decimalPart = adventure.InsurenceMinimalAmount - Math.Truncate(adventure.InsurenceMinimalAmount.Value);

            var decimalPartSize = decimalPart.Value.ToString().Replace("0.", "").Length;

            return decimalPartSize <= 2;
        }
    }
}
