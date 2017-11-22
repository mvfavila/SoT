using SoT.Domain.Entities;
using SoT.Domain.Validation.Base;
using SoT.Domain.Specification.Address;

namespace SoT.Domain.Validation
{
    public class AddressIsVerified : BaseSupervisor<Address>
    {
        public AddressIsVerified()
        {
            var isStreet01NotNullAndNotEmpty = new AddressIsStreet01NotNullAndNotEmpty();
            var isStreet01ValidLength = new AddressIsStreet01ValidLength();
            var isComplementValidLength = new AddressIsComplementValidLength();
            var isPostcodeValidLength = new AddressIsPostcodeValidLength();
            var isAdventureIdNotNull = new AddressIsAdventureIdNotNull();
            var isAdventureNotNull = new AddressIsAdventureNotNull();

            base.AddRule("IsStreet01NotNullAndNotEmpty", new Rule<Address>(isStreet01NotNullAndNotEmpty,
                $"{nameof(Address.Street01)} is required"));
            base.AddRule("IsStreet01ValidLength", new Rule<Address>(isStreet01ValidLength,
                $"{nameof(Address.Street01)} can not have more than 300 chars"));
            base.AddRule("IsComplementValidLength", new Rule<Address>(isComplementValidLength,
                $"{nameof(Address.Complement)} can not have more than 300 chars"));
            base.AddRule("IsPostcodeValidLength", new Rule<Address>(isPostcodeValidLength,
                $"{nameof(Address.Postcode)} can not have more than 30 chars"));
            base.AddRule("IsAdventureIdNotNull", new Rule<Address>(isAdventureIdNotNull,
                $"{nameof(Address.AdventureId)} is required"));
            base.AddRule("IsAdventureNotNull", new Rule<Address>(isAdventureNotNull,
                $"{nameof(Address.Adventure)} is required"));
        }
    }
}
