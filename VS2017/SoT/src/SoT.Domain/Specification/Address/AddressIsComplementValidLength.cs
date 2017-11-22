using SoT.Domain.Interfaces.Specification;

namespace SoT.Domain.Specification.Address
{
    public class AddressIsComplementValidLength : ISpecification<Entities.Address>
    {
        const int COMPLEMENT_MAX_LENGTH = 300;

        public bool IsSatisfiedBy(Entities.Address address)
        {
            return address.Complement.Length <= COMPLEMENT_MAX_LENGTH;
        }
    }
}
