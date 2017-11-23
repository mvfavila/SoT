using SoT.Domain.Specification.Country;
using SoT.Domain.Validation.Base;

namespace SoT.Domain.Validation.Country
{
    public class CountryIsVerifiedForRegistration : BaseSupervisor<Entities.Country>
    {
        public CountryIsVerifiedForRegistration()
        {
            var isKeyNotNull = new CountryIsKeyNotNull();
            var isNameNotNullAndNotEmpty = new CountryIsNameNotNullAndNotEmpty();
            var isNameValidLength = new CountryIsNameValidLength();
            var isRegionNotNull = new CountryIsRegionNotNull();

            base.AddRule("IsKeyNotNull", new Rule<Entities.Country>(isKeyNotNull,
                $"{nameof(Entities.Country.CountryId)} is required"));

            base.AddRule("IsNameNotNullAndNotEmpty", new Rule<Entities.Country>(isNameNotNullAndNotEmpty,
                $"{nameof(Entities.Country.Name)} is required"));

            base.AddRule("IsNameValidLength", new Rule<Entities.Country>(isNameValidLength,
                $"{nameof(Entities.Country.Name)} can not have more than 70 chars"));

            base.AddRule("IsRegionNotNull", new Rule<Entities.Country>(isRegionNotNull,
                $"{nameof(Entities.Country.Region)} is required"));
        }
    }
}
