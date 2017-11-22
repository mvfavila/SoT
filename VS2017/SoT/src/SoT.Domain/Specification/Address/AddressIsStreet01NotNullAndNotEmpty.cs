using SoT.Domain.Interfaces.Specification;

namespace SoT.Domain.Specification.Address
{
    public class AddressIsStreet01NotNullAndNotEmpty : ISpecification<Entities.Address>
    {
        public bool IsSatisfiedBy(Entities.Address address)
        {
            return !string.IsNullOrEmpty(address.Street01) && !string.IsNullOrWhiteSpace(address.Street01);
        }
    }
}
