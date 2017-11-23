using SoT.Domain.Specification.Address;
using SoT.Domain.Validation.Base;

namespace SoT.Domain.Validation.Address
{
    public class AddressIsVerified : BaseSupervisor<Entities.Address>
    {
        public AddressIsVerified()
        {
            var isKeyNotNull = new AddressIsKeyNotNull();
            var isStreet01NotNullAndNotEmpty = new AddressIsStreet01NotNullAndNotEmpty();
            var isStreet01ValidLength = new AddressIsStreet01ValidLength();
            var isComplementValidLength = new AddressIsComplementValidLength();
            var isPostcodeValidLength = new AddressIsPostcodeValidLength();
            var isAdventureIdNotNull = new AddressIsAdventureIdNotNull();

            base.AddRule("IsKeyNotNull", new Rule<Entities.Address>(isKeyNotNull,
                $"{nameof(Entities.Address.AddressId)} is required"));
            base.AddRule("IsStreet01NotNullAndNotEmpty", new Rule<Entities.Address>(isStreet01NotNullAndNotEmpty,
                $"{nameof(Entities.Address.Street01)} is required"));
            base.AddRule("IsStreet01ValidLength", new Rule<Entities.Address>(isStreet01ValidLength,
                $"{nameof(Entities.Address.Street01)} can not have more than 300 chars"));
            base.AddRule("IsComplementValidLength", new Rule<Entities.Address>(isComplementValidLength,
                $"{nameof(Entities.Address.Complement)} can not have more than 300 chars"));
            base.AddRule("IsPostcodeValidLength", new Rule<Entities.Address>(isPostcodeValidLength,
                $"{nameof(Entities.Address.Postcode)} can not have more than 30 chars"));
            base.AddRule("IsAdventureIdNotNull", new Rule<Entities.Address>(isAdventureIdNotNull,
                $"{nameof(Entities.Address.AdventureId)} is required"));
        }
    }
}
