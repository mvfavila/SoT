using SoT.Domain.Tests.Shared;
using System.Linq;
using Xunit;

namespace SoT.Domain.Tests.Validation.Adventure
{
    public class AdventureIsVerifiedForRegistrationTest
    {
        [Fact(DisplayName = "Valid instance")]
        [Trait(nameof(Adventure), "Instantiation")]
        public void Adventure_Instantiate_MustBeValid()
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

            Assert.True(isValid);
            Assert.False(adventure.ValidationResult.Errors.Any());
        }

        [Fact(DisplayName = "Id is required")]
        [Trait(nameof(Adventure), "Instantiation")]
        public void Adventure_Instantiate_KeyMustNotBeNull()
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

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Adventure.AdventureId)} is required",
                adventure.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact(DisplayName = "Name is required (Not null)")]
        [Trait(nameof(Adventure), "Instantiation")]
        public void Adventure_Instantiate_NameMustNotBeNull()
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

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Adventure.Name)} is required",
                adventure.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact(DisplayName = "Name is required (Not empty)")]
        [Trait(nameof(Adventure), "Instantiation")]
        public void Adventure_Instantiate_NameMustNotBeEmpty()
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

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Adventure.Name)} is required",
                adventure.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact(DisplayName = "Name is required (Not empty spaces)")]
        [Trait(nameof(Adventure), "Instantiation")]
        public void Adventure_Instantiate_NameMustNotBeEmptySpaces()
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

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Adventure.Name)} is required",
                adventure.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact(DisplayName = "Name must have 250 chars or less")]
        [Trait(nameof(Adventure), "Instantiation")]
        public void Adventure_Instantiate_NameMustHaveValidLength()
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

            Assert.True(isValid);

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

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Adventure.Name)} can not have more than 250 chars",
                adventure.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact(DisplayName = "Category Id is required")]
        [Trait(nameof(Adventure), "Instantiation")]
        public void Adventure_Instantiate_CategoryMustNotBeNull()
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

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Adventure.Category)} is required",
                adventure.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact(DisplayName = "City Id is required")]
        [Trait(nameof(Adventure), "Instantiation")]
        public void Adventure_Instantiate_CityMustNotBeNull()
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

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Adventure.City)} is required",
                adventure.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact(DisplayName = "Address Id is required")]
        [Trait(nameof(Adventure), "Instantiation")]
        public void Adventure_Instantiate_AddressMustNotBeNull()
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

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Adventure.Address)} is required",
                adventure.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact(DisplayName = "Insurance Minimal Amount must be higher than 0 (zero)")]
        [Trait(nameof(Adventure), "Instantiation")]
        public void Adventure_Instantiate_InsurenceMinimalAmountMustBeHigherThanZero()
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

            Assert.False(isValid);
            Assert.Contains(
                $"{nameof(Domain.Entities.Adventure.InsurenceMinimalAmount)} has to be higher than 0(zero)",
                adventure.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact(DisplayName = "Insurance Minimal Amount must be 9,999,999.99 or less")]
        [Trait(nameof(Adventure), "Instantiation")]
        public void Adventure_Instantiate_InsurenceMinimalAmountMustBeLessThanMaxValue()
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

            Assert.True(isValid);

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

            Assert.False(isValid);
            Assert.Contains(
                $"{nameof(Domain.Entities.Adventure.InsurenceMinimalAmount)} can not be higher than 9999999.99",
                adventure.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact(DisplayName = "Insurance Minimal Amount must 2 (two) or less decimal places")]
        [Trait(nameof(Adventure), "Instantiation")]
        public void Adventure_Instantiate_InsurenceMinimalAmountMustHaveTwoOrLessDecimalPlaces()
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

            Assert.True(isValid);

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

            Assert.True(isValid);

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

            Assert.True(isValid);

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

            Assert.False(isValid);
            Assert.Contains(
                $"{nameof(Domain.Entities.Adventure.InsurenceMinimalAmount)} can not have more than 2 decimal places",
                adventure.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact(DisplayName = "Provider Id is required")]
        [Trait(nameof(Adventure), "Instantiation")]
        public void Adventure_Instantiate_ProviderMustNotBeNull()
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

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Adventure.Provider)} is required",
                adventure.ValidationResult.Errors.Select(error => error.Message).ToList());
        }
    }
}
