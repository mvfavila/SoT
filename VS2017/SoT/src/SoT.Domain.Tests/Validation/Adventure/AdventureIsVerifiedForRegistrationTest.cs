using NUnit.Framework;
using SoT.Domain.Tests.Shared;
using System.Linq;

namespace SoT.Domain.Tests.Validation.Adventure
{
    [TestFixture]
    public class AdventureIsVerifiedForRegistrationTest
    {
        [Test]
        public void AdventureMustBeValid()
        {
            var adventure = Domain.Entities.Adventure.FactoryTest(
                TestConstants.ADVENTURE_ID_VALID,
                TestConstants.ADVENTURE_NAME_VALID,
                TestConstants.CATEGORY_ID_VALID,
                TestConstants.CATEGORY_VALID,
                TestConstants.CITY_ID_VALID,
                TestConstants.CITY_VALID,
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.ADDRESS_VALID,
                TestConstants.INSURANCE_MINIMAL_VALID,
                TestConstants.PROVIDER_ID_VALID,
                TestConstants.PROVIDER_VALID,
                TestConstants.AVAILABILITIES_VALID,
                TestConstants.USER_ID_VALID,
                TestConstants.ACTIVE
                );

            var isValid = adventure.IsValid();

            Assert.IsTrue(isValid);
            Assert.IsFalse(adventure.ValidationResult.Errors.Any());
        }

        [Test]
        public void AdventureKeyMustNotBeNull()
        {
            var adventure = Domain.Entities.Adventure.FactoryTest(
                TestConstants.ADVENTURE_ID_INVALID,
                TestConstants.ADVENTURE_NAME_VALID,
                TestConstants.CATEGORY_ID_VALID,
                TestConstants.CATEGORY_VALID,
                TestConstants.CITY_ID_VALID,
                TestConstants.CITY_VALID,
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.ADDRESS_VALID,
                TestConstants.INSURANCE_MINIMAL_VALID,
                TestConstants.PROVIDER_ID_VALID,
                TestConstants.PROVIDER_VALID,
                TestConstants.AVAILABILITIES_VALID,
                TestConstants.USER_ID_VALID,
                TestConstants.ACTIVE
                );

            var isValid = adventure.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Adventure.AdventureId)} is required",
                adventure.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Test]
        public void AdventureNameMustNotBeNull()
        {
            var adventure = Domain.Entities.Adventure.FactoryTest(
                TestConstants.ADVENTURE_ID_VALID,
                TestConstants.ADVENTURE_NAME_INVALID_NULL,
                TestConstants.CATEGORY_ID_VALID,
                TestConstants.CATEGORY_VALID,
                TestConstants.CITY_ID_VALID,
                TestConstants.CITY_VALID,
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.ADDRESS_VALID,
                TestConstants.INSURANCE_MINIMAL_VALID,
                TestConstants.PROVIDER_ID_VALID,
                TestConstants.PROVIDER_VALID,
                TestConstants.AVAILABILITIES_VALID,
                TestConstants.USER_ID_VALID,
                TestConstants.ACTIVE
                );

            var isValid = adventure.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Adventure.Name)} is required",
                adventure.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Test]
        public void AdventureNameMustNotBeEmpty()
        {
            var adventure = Domain.Entities.Adventure.FactoryTest(
                TestConstants.ADVENTURE_ID_VALID,
                TestConstants.ADVENTURE_NAME_INVALID_EMPTY,
                TestConstants.CATEGORY_ID_VALID,
                TestConstants.CATEGORY_VALID,
                TestConstants.CITY_ID_VALID,
                TestConstants.CITY_VALID,
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.ADDRESS_VALID,
                TestConstants.INSURANCE_MINIMAL_VALID,
                TestConstants.PROVIDER_ID_VALID,
                TestConstants.PROVIDER_VALID,
                TestConstants.AVAILABILITIES_VALID,
                TestConstants.USER_ID_VALID,
                TestConstants.ACTIVE
                );

            var isValid = adventure.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Adventure.Name)} is required",
                adventure.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Test]
        public void AdventureNameMustNotBeEmptySpaces()
        {
            var adventure = Domain.Entities.Adventure.FactoryTest(
                TestConstants.ADVENTURE_ID_VALID,
                TestConstants.ADVENTURE_NAME_INVALID_EMPTY_SPACES,
                TestConstants.CATEGORY_ID_VALID,
                TestConstants.CATEGORY_VALID,
                TestConstants.CITY_ID_VALID,
                TestConstants.CITY_VALID,
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.ADDRESS_VALID,
                TestConstants.INSURANCE_MINIMAL_VALID,
                TestConstants.PROVIDER_ID_VALID,
                TestConstants.PROVIDER_VALID,
                TestConstants.AVAILABILITIES_VALID,
                TestConstants.USER_ID_VALID,
                TestConstants.ACTIVE
                );

            var isValid = adventure.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Adventure.Name)} is required",
                adventure.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Test]
        public void AdventureNameMustHaveValidLength()
        {
            var adventure = Domain.Entities.Adventure.FactoryTest(
                TestConstants.ADVENTURE_ID_VALID,
                TestConstants.ADVENTURE_NAME_VALID_LENGTH_EDGE,
                TestConstants.CATEGORY_ID_VALID,
                TestConstants.CATEGORY_VALID,
                TestConstants.CITY_ID_VALID,
                TestConstants.CITY_VALID,
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.ADDRESS_VALID,
                TestConstants.INSURANCE_MINIMAL_VALID,
                TestConstants.PROVIDER_ID_VALID,
                TestConstants.PROVIDER_VALID,
                TestConstants.AVAILABILITIES_VALID,
                TestConstants.USER_ID_VALID,
                TestConstants.ACTIVE
                );

            var isValid = adventure.IsValid();

            Assert.IsTrue(isValid);

            adventure = Domain.Entities.Adventure.FactoryTest(
                TestConstants.ADVENTURE_ID_VALID,
                TestConstants.ADVENTURE_NAME_INVALID_LENGTH,
                TestConstants.CATEGORY_ID_VALID,
                TestConstants.CATEGORY_VALID,
                TestConstants.CITY_ID_VALID,
                TestConstants.CITY_VALID,
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.ADDRESS_VALID,
                TestConstants.INSURANCE_MINIMAL_VALID,
                TestConstants.PROVIDER_ID_VALID,
                TestConstants.PROVIDER_VALID,
                TestConstants.AVAILABILITIES_VALID,
                TestConstants.USER_ID_VALID,
                TestConstants.ACTIVE
                );

            isValid = adventure.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Adventure.Name)} can not have more than 250 chars",
                adventure.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Test]
        public void AdventureCategoryMustNotBeNull()
        {
            var adventure = Domain.Entities.Adventure.FactoryTest(
                TestConstants.ADVENTURE_ID_VALID,
                TestConstants.ADVENTURE_NAME_VALID,
                TestConstants.CATEGORY_ID_INVALID,
                TestConstants.CATEGORY_VALID,
                TestConstants.CITY_ID_VALID,
                TestConstants.CITY_VALID,
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.ADDRESS_VALID,
                TestConstants.INSURANCE_MINIMAL_VALID,
                TestConstants.PROVIDER_ID_VALID,
                TestConstants.PROVIDER_VALID,
                TestConstants.AVAILABILITIES_VALID,
                TestConstants.USER_ID_VALID,
                TestConstants.ACTIVE
                );

            var isValid = adventure.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Adventure.Category)} is required",
                adventure.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Test]
        public void AdventureCityMustNotBeNull()
        {
            var adventure = Domain.Entities.Adventure.FactoryTest(
                TestConstants.ADVENTURE_ID_VALID,
                TestConstants.ADVENTURE_NAME_VALID,
                TestConstants.CATEGORY_ID_VALID,
                TestConstants.CATEGORY_VALID,
                TestConstants.CITY_ID_INVALID,
                TestConstants.CITY_VALID,
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.ADDRESS_VALID,
                TestConstants.INSURANCE_MINIMAL_VALID,
                TestConstants.PROVIDER_ID_VALID,
                TestConstants.PROVIDER_VALID,
                TestConstants.AVAILABILITIES_VALID,
                TestConstants.USER_ID_VALID,
                TestConstants.ACTIVE
                );

            var isValid = adventure.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Adventure.City)} is required",
                adventure.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Test]
        public void AdventureAddressMustNotBeNull()
        {
            var adventure = Domain.Entities.Adventure.FactoryTest(
                TestConstants.ADVENTURE_ID_VALID,
                TestConstants.ADVENTURE_NAME_VALID,
                TestConstants.CATEGORY_ID_VALID,
                TestConstants.CATEGORY_VALID,
                TestConstants.CITY_ID_VALID,
                TestConstants.CITY_VALID,
                TestConstants.ADDRESS_ID_INVALID,
                TestConstants.ADDRESS_VALID,
                TestConstants.INSURANCE_MINIMAL_VALID,
                TestConstants.PROVIDER_ID_VALID,
                TestConstants.PROVIDER_VALID,
                TestConstants.AVAILABILITIES_VALID,
                TestConstants.USER_ID_VALID,
                TestConstants.ACTIVE
                );

            var isValid = adventure.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Adventure.Address)} is required",
                adventure.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Test]
        public void AdventureInsurenceMinimalAmountMustBeHigherThanZero()
        {
            var adventure = Domain.Entities.Adventure.FactoryTest(
                TestConstants.ADVENTURE_ID_VALID,
                TestConstants.ADVENTURE_NAME_VALID,
                TestConstants.CATEGORY_ID_VALID,
                TestConstants.CATEGORY_VALID,
                TestConstants.CITY_ID_VALID,
                TestConstants.CITY_VALID,
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.ADDRESS_VALID,
                TestConstants.INSURANCE_MINIMAL_INVALID_NEGATIVE,
                TestConstants.PROVIDER_ID_VALID,
                TestConstants.PROVIDER_VALID,
                TestConstants.AVAILABILITIES_VALID,
                TestConstants.USER_ID_VALID,
                TestConstants.ACTIVE
                );

            var isValid = adventure.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains(
                $"{nameof(Domain.Entities.Adventure.InsurenceMinimalAmount)} has to be higher than 0(zero)",
                adventure.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Test]
        public void AdventureInsurenceMinimalAmountMustBeLessThanMaxValue()
        {
            var adventure = Domain.Entities.Adventure.FactoryTest(
                TestConstants.ADVENTURE_ID_VALID,
                TestConstants.ADVENTURE_NAME_VALID,
                TestConstants.CATEGORY_ID_VALID,
                TestConstants.CATEGORY_VALID,
                TestConstants.CITY_ID_VALID,
                TestConstants.CITY_VALID,
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.ADDRESS_VALID,
                TestConstants.INSURANCE_MINIMAL_VALID_EDGE,
                TestConstants.PROVIDER_ID_VALID,
                TestConstants.PROVIDER_VALID,
                TestConstants.AVAILABILITIES_VALID,
                TestConstants.USER_ID_VALID,
                TestConstants.ACTIVE
                );

            var isValid = adventure.IsValid();

            Assert.IsTrue(isValid);

            adventure = Domain.Entities.Adventure.FactoryTest(
                TestConstants.ADVENTURE_ID_VALID,
                TestConstants.ADVENTURE_NAME_VALID,
                TestConstants.CATEGORY_ID_VALID,
                TestConstants.CATEGORY_VALID,
                TestConstants.CITY_ID_VALID,
                TestConstants.CITY_VALID,
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.ADDRESS_VALID,
                TestConstants.INSURANCE_MINIMAL_INVALID_HIGHER_THAN_MAX_VALUE,
                TestConstants.PROVIDER_ID_VALID,
                TestConstants.PROVIDER_VALID,
                TestConstants.AVAILABILITIES_VALID,
                TestConstants.USER_ID_VALID,
                TestConstants.ACTIVE
                );

            isValid = adventure.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains(
                $"{nameof(Domain.Entities.Adventure.InsurenceMinimalAmount)} can not be higher than 9999999.99",
                adventure.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Test]
        public void AdventureInsurenceMinimalAmountMustHaveTwoOrLessDecimalPlaces()
        {
            var adventure = Domain.Entities.Adventure.FactoryTest(
                TestConstants.ADVENTURE_ID_VALID,
                TestConstants.ADVENTURE_NAME_VALID,
                TestConstants.CATEGORY_ID_VALID,
                TestConstants.CATEGORY_VALID,
                TestConstants.CITY_ID_VALID,
                TestConstants.CITY_VALID,
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.ADDRESS_VALID,
                TestConstants.INSURANCE_MINIMAL_VALID_NO_DECIMAL_PLACES,
                TestConstants.PROVIDER_ID_VALID,
                TestConstants.PROVIDER_VALID,
                TestConstants.AVAILABILITIES_VALID,
                TestConstants.USER_ID_VALID,
                TestConstants.ACTIVE
                );

            var isValid = adventure.IsValid();

            Assert.IsTrue(isValid);

            adventure = Domain.Entities.Adventure.FactoryTest(
                TestConstants.ADVENTURE_ID_VALID,
                TestConstants.ADVENTURE_NAME_VALID,
                TestConstants.CATEGORY_ID_VALID,
                TestConstants.CATEGORY_VALID,
                TestConstants.CITY_ID_VALID,
                TestConstants.CITY_VALID,
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.ADDRESS_VALID,
                TestConstants.INSURANCE_MINIMAL_VALID_ONE_DECIMAL_PLACES,
                TestConstants.PROVIDER_ID_VALID,
                TestConstants.PROVIDER_VALID,
                TestConstants.AVAILABILITIES_VALID,
                TestConstants.USER_ID_VALID,
                TestConstants.ACTIVE
                );

            isValid = adventure.IsValid();

            Assert.IsTrue(isValid);

            adventure = Domain.Entities.Adventure.FactoryTest(
                TestConstants.ADVENTURE_ID_VALID,
                TestConstants.ADVENTURE_NAME_VALID,
                TestConstants.CATEGORY_ID_VALID,
                TestConstants.CATEGORY_VALID,
                TestConstants.CITY_ID_VALID,
                TestConstants.CITY_VALID,
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.ADDRESS_VALID,
                TestConstants.INSURANCE_MINIMAL_VALID_TWO_DECIMAL_PLACES,
                TestConstants.PROVIDER_ID_VALID,
                TestConstants.PROVIDER_VALID,
                TestConstants.AVAILABILITIES_VALID,
                TestConstants.USER_ID_VALID,
                TestConstants.ACTIVE
                );

            isValid = adventure.IsValid();

            Assert.IsTrue(isValid);

            adventure = Domain.Entities.Adventure.FactoryTest(
                TestConstants.ADVENTURE_ID_VALID,
                TestConstants.ADVENTURE_NAME_VALID,
                TestConstants.CATEGORY_ID_VALID,
                TestConstants.CATEGORY_VALID,
                TestConstants.CITY_ID_VALID,
                TestConstants.CITY_VALID,
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.ADDRESS_VALID,
                TestConstants.INSURANCE_MINIMAL_INVALID_THREE_DECIMAL_PLACES,
                TestConstants.PROVIDER_ID_VALID,
                TestConstants.PROVIDER_VALID,
                TestConstants.AVAILABILITIES_VALID,
                TestConstants.USER_ID_VALID,
                TestConstants.ACTIVE
                );

            isValid = adventure.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains(
                $"{nameof(Domain.Entities.Adventure.InsurenceMinimalAmount)} can not have more than 2 decimal places",
                adventure.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Test]
        public void AdventureProviderMustNotBeNull()
        {
            var adventure = Domain.Entities.Adventure.FactoryTest(
                TestConstants.ADVENTURE_ID_VALID,
                TestConstants.ADVENTURE_NAME_VALID,
                TestConstants.CATEGORY_ID_VALID,
                TestConstants.CATEGORY_VALID,
                TestConstants.CITY_ID_VALID,
                TestConstants.CITY_VALID,
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.ADDRESS_VALID,
                TestConstants.INSURANCE_MINIMAL_VALID,
                TestConstants.PROVIDER_ID_INVALID,
                TestConstants.PROVIDER_VALID,
                TestConstants.AVAILABILITIES_VALID,
                TestConstants.USER_ID_VALID,
                TestConstants.ACTIVE
                );

            var isValid = adventure.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Adventure.Provider)} is required",
                adventure.ValidationResult.Errors.Select(error => error.Message).ToList());
        }
    }
}
