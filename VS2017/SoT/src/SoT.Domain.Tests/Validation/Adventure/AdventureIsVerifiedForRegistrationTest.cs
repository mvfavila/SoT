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
        public void AddressStreet01MustHaveValidLength()
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
    }
}
