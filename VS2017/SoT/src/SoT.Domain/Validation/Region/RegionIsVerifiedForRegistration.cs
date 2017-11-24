using SoT.Domain.Specification.Region;
using SoT.Domain.Validation.Base;

namespace SoT.Domain.Validation.Region
{
    public class RegionIsVerifiedForRegistration : BaseSupervisor<Entities.Region>
    {
        public RegionIsVerifiedForRegistration()
        {
            var isKeyNotNull = new RegionIsKeyNotNull();
            var isNameNotNullAndNotEmpty = new RegionIsNameNotNullAndNotEmpty();
            var isNameValidLength = new RegionIsNameValidLength();
            var isContinentNotNull = new RegionIsRegionNotNull();

            base.AddRule("IsKeyNotNull", new Rule<Entities.Region>(isKeyNotNull,
                $"{nameof(Entities.Region.RegionId)} is required"));

            base.AddRule("IsNameNotNullAndNotEmpty", new Rule<Entities.Region>(isNameNotNullAndNotEmpty,
                $"{nameof(Entities.Region.Name)} is required"));

            base.AddRule("IsNameValidLength", new Rule<Entities.Region>(isNameValidLength,
                $"{nameof(Entities.Region.Name)} can not have more than 100 chars"));

            base.AddRule("IsContinentNotNull", new Rule<Entities.Region>(isContinentNotNull,
                $"{nameof(Entities.Region.ContinentId)} is required"));
        }
    }
}
