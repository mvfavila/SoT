using SoT.Domain.Specification.Gender;
using SoT.Domain.Validation.Base;

namespace SoT.Domain.Validation.Gender
{
    public class GenderIsVerifiedForRegistration : BaseSupervisor<Entities.Gender>
    {
        public GenderIsVerifiedForRegistration()
        {
            var isKeyNotNull = new GenderIsKeyNotNull();
            var isValueNotNullAndNotEmpty = new GenderIsValueNotNullAndNotEmpty();
            var isValueValidLength = new GenderIsValueValidLength();

            base.AddRule("IsKeyNotNull", new Rule<Entities.Gender>(isKeyNotNull,
                $"{nameof(Entities.Gender.GenderId)} is required"));

            base.AddRule("IsValueNotNullAndNotEmpty", new Rule<Entities.Gender>(isValueNotNullAndNotEmpty,
                $"{nameof(Entities.Gender.Value)} is required"));

            base.AddRule("IsValueValidLength", new Rule<Entities.Gender>(isValueValidLength,
                $"{nameof(Entities.Gender.Value)} can not have more than 30 chars"));
        }
    }
}
