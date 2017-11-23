using SoT.Domain.Specification.City;
using SoT.Domain.Validation.Base;

namespace SoT.Domain.Validation.City
{
    public class CityIsVerifiedForRegistration : BaseSupervisor<Entities.City>
    {
        public CityIsVerifiedForRegistration()
        {
            var isKeyNotNull = new CityIsKeyNotNull();
            var isNameNotNullAndNotEmpty = new CityIsNameNotNullAndNotEmpty();
            var isNameValidLength = new CityIsNameValidLength();
            var isCountryNotNull = new CityIsCountryNotNull();

            base.AddRule("IsKeyNotNull", new Rule<Entities.City>(isKeyNotNull,
                $"{nameof(Entities.City.CityId)} is required"));

            base.AddRule("IsNameNotNullAndNotEmpty", new Rule<Entities.City>(isNameNotNullAndNotEmpty,
                $"{nameof(Entities.City.Name)} is required"));

            base.AddRule("IsNameValidLength", new Rule<Entities.City>(isNameValidLength,
                $"{nameof(Entities.City.Name)} can not have more than 100 chars"));

            base.AddRule("IsCountryNotNull", new Rule<Entities.City>(isCountryNotNull,
                $"{nameof(Entities.City.Country)} is required"));
        }
    }
}
