using SoT.Domain.Entities;
using SoT.Domain.Validation.Base;
using SoT.Domain.Specification.Address;

namespace SoT.Domain.Validation
{
    public class AddressIsVerified : BaseSupervisor<Address>
    {
        public AddressIsVerified()
        {
            var isAttachedToAdventure = new AddressIsAttachedToAdventure();

            base.AddRule("IsAttachedToAdventure", new Rule<Address>(isAttachedToAdventure,
                $"{nameof(Address)} must be attached to an {nameof(Adventure)}"));
        }
    }
}
