using SoT.Domain.Interfaces.Specification;
using System;

namespace SoT.Domain.Specification.Address
{
    public class AddressIsKeyNotNull : ISpecification<Entities.Address>
    {
        public bool IsSatisfiedBy(Entities.Address address)
        {
            return address.AddressId != Guid.Empty;
        }
    }
}
