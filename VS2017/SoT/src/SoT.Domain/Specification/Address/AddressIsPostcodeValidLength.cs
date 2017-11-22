using SoT.Domain.Interfaces.Specification;

namespace SoT.Domain.Specification.Address
{
    public class AddressIsPostcodeValidLength : ISpecification<Entities.Address>
    {
        const int POSTCODE_MAX_LENGTH = 30;

        public bool IsSatisfiedBy(Entities.Address address)
        {
            if (address.Postcode == null)
                return true;

            return address.Postcode.Length <= POSTCODE_MAX_LENGTH;
        }
    }
}
