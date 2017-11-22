using SoT.Domain.Interfaces.Specification;

namespace SoT.Domain.Specification.Address
{
    public class AddressIsAdventureNotNull : ISpecification<Entities.Address>
    {
        public bool IsSatisfiedBy(Entities.Address address)
        {
            return address.Adventure != null;
        }
    }
}
