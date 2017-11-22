using SoT.Domain.Interfaces.Specification;
using System;

namespace SoT.Domain.Specification.Address
{
    public class AddressIsAdventureIdNotNull : ISpecification<Entities.Address>
    {
        public bool IsSatisfiedBy(Entities.Address address)
        {
            return address.AdventureId != Guid.Empty;
        }
    }
}
