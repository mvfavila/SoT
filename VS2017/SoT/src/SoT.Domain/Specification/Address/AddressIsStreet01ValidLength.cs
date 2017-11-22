using SoT.Domain.Interfaces.Specification;

namespace SoT.Domain.Specification.Address
{
    public class AddressIsStreet01ValidLength : ISpecification<Entities.Address>
    {
        const int STREET01_MAX_LENGTH = 300;

        public bool IsSatisfiedBy(Entities.Address address)
        {
            if (address.Street01 == null)
                return true;

            return address.Street01.Length <= STREET01_MAX_LENGTH;
        }
    }
}
