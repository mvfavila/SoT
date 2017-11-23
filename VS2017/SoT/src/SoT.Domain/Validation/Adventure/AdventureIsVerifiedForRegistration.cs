using SoT.Domain.Specification.Adventure;
using SoT.Domain.Validation.Base;

namespace SoT.Domain.Validation.Adventure
{
    public class AdventureIsVerifiedForRegistration : BaseSupervisor<Entities.Adventure>
    {
        public AdventureIsVerifiedForRegistration()
        {
            var isKeyNotNull                              = new AdventureIsKeyNotNull();
            var isNameNotNullAndNotEmpty                  = new AdventureIsNameNotNullAndNotEmpty();
            var isNameValidLength                         = new AdventureIsNameValidLength();
            var isCategoryNotNull                         = new AdventureIsCategoryNotNull();
            var isCityNotNull                             = new AdventureIsCityNotNull();
            var isAddressNotNull                          = new AdventureIsAddressNotNull();
            var isInsurenceMinimalAmountHigherThenZero    = new AdventureIsInsurenceMinimalAmountHigherThenZero();
            var isInsurenceMinimalAmountLowerThanMaxValue = new AdventureIsInsurenceMinimalAmountLowerThanMaxValue();
            var isInsurenceMinimalAmountTwoDecimalPlaces  = new AdventureisInsurenceMinimalAmountTwoDecimalPlaces();
            var isProviderNotNull                         = new AdventureIsProviderNotNull();

            base.AddRule("IsKeyNotNull", new Rule<Entities.Adventure>(isKeyNotNull,
                $"{nameof(Entities.Adventure.AdventureId)} is required"));

            base.AddRule("IsNameNotNullAndNotEmpty", new Rule<Entities.Adventure>(isNameNotNullAndNotEmpty,
                $"{nameof(Entities.Adventure.Name)} is required"));

            base.AddRule("IsNameValidLength", new Rule<Entities.Adventure>(isNameValidLength,
                $"{nameof(Entities.Adventure.Name)} can not have more than 250 chars"));

            base.AddRule("IsCategoryNotNull", new Rule<Entities.Adventure>(isCategoryNotNull,
                $"{nameof(Entities.Adventure.Category)} is required"));

            base.AddRule("IsCityNotNull", new Rule<Entities.Adventure>(isCityNotNull,
                $"{nameof(Entities.Adventure.City)} is required"));

            base.AddRule("IsAddressNotNull", new Rule<Entities.Adventure>(isAddressNotNull,
                $"{nameof(Entities.Adventure.Address)} is required"));

            base.AddRule("IsInsurenceMinimalAmountHigherThenZero", new Rule<Entities.Adventure>(
                isInsurenceMinimalAmountHigherThenZero,
                $"{nameof(Entities.Adventure.InsurenceMinimalAmount)} has to be higher than 0(zero)"));

            base.AddRule("IsInsurenceMinimalAmountLowerThanMaxValue", new Rule<Entities.Adventure>(
                isInsurenceMinimalAmountLowerThanMaxValue,
                $"{nameof(Entities.Adventure.InsurenceMinimalAmount)} can not be higher than 9999999.99"));

            base.AddRule("IsInsurenceMinimalAmountTwoDecimalPlaces", new Rule<Entities.Adventure>(
                isInsurenceMinimalAmountTwoDecimalPlaces,
                $"{nameof(Entities.Adventure.InsurenceMinimalAmount)} can not have more than 2 decimal places"));

            base.AddRule("IsProviderNotNull", new Rule<Entities.Adventure>(isProviderNotNull,
                $"{nameof(Entities.Adventure.Provider)} is required"));
        }
    }
}
