using SoT.Domain.Specification.Provider;
using SoT.Domain.Validation.Base;

namespace SoT.Domain.Validation.Provider
{
    public class ProviderIsVerifiedForRegistration : BaseSupervisor<Entities.Provider>
    {
        public ProviderIsVerifiedForRegistration()
        {
            var isKeyNotNull = new ProviderIsKeyNotNull();
            var isCompanyNameNotNullAndNotEmpty = new ProviderIsCompanyNameNotNullAndNotEmpty();
            var isCompanyNameValidLength = new ProviderIsCompanyNameValidLength();

            base.AddRule("IsKeyNotNull", new Rule<Entities.Provider>(isKeyNotNull,
                $"{nameof(Entities.Provider.ProviderId)} is required"));

            base.AddRule("IsCompanyNameNotNullAndNotEmpty", new Rule<Entities.Provider>(
                isCompanyNameNotNullAndNotEmpty,
                $"{nameof(Entities.Provider.CompanyName)} is required"));

            base.AddRule("IsCompanyNameValidLength", new Rule<Entities.Provider>(isCompanyNameValidLength,
                $"{nameof(Entities.Provider.CompanyName)} can not have more than 400 chars"));
        }
    }
}
