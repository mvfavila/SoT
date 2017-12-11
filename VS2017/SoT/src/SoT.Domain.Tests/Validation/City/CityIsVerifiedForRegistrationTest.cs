using SoT.Domain.Tests.Shared;
using System.Linq;
using Xunit;

namespace SoT.Domain.Tests.Validation.City
{
    public class CityIsVerifiedForRegistrationTest
    {
        [Fact(DisplayName = "Valid instance")]
        [Trait(nameof(City), "Instantiation")]
        public void City_Instantiate_MustBeValid()
        {
            var city = Domain.Entities.City.FactoryTest(
                TestConstants.CITY_ID_VALID,
                TestConstants.CITY_NAME_VALID,
                TestConstants.ACTIVE,
                TestConstants.COUNTRY_ID_VALID,
                TestConstants.COUNTRY_VALID
                );

            var isValid = city.IsValid();

            Assert.True(isValid);
            Assert.False(city.ValidationResult.Errors.Any());
        }

        [Fact(DisplayName = "Id is required")]
        [Trait(nameof(City), "Instantiation")]
        public void City_Instantiate_KeyMustNotBeNull()
        {
            var city = Domain.Entities.City.FactoryTest(
                TestConstants.CITY_ID_INVALID,
                TestConstants.CITY_NAME_VALID,
                TestConstants.ACTIVE,
                TestConstants.COUNTRY_ID_VALID,
                TestConstants.COUNTRY_VALID
                );

            var isValid = city.IsValid();

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.City.CityId)} is required",
                city.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact(DisplayName = "Name is required (Not null)")]
        [Trait(nameof(City), "Instantiation")]
        public void City_Instantiate_NameMustNotBeNull()
        {
            var city = Domain.Entities.City.FactoryTest(
                TestConstants.CITY_ID_VALID,
                TestConstants.CITY_NAME_INVALID_NULL,
                TestConstants.ACTIVE,
                TestConstants.COUNTRY_ID_VALID,
                TestConstants.COUNTRY_VALID
                );

            var isValid = city.IsValid();

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.City.Name)} is required",
                city.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact(DisplayName = "Name is required (Not empty)")]
        [Trait(nameof(City), "Instantiation")]
        public void City_Instantiate_NameMustNotBeEmpty()
        {
            var city = Domain.Entities.City.FactoryTest(
                TestConstants.CITY_ID_VALID,
                TestConstants.CITY_NAME_INVALID_EMPTY,
                TestConstants.ACTIVE,
                TestConstants.COUNTRY_ID_VALID,
                TestConstants.COUNTRY_VALID
                );

            var isValid = city.IsValid();

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.City.Name)} is required",
                city.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact(DisplayName = "Name is required (Not empty spaces)")]
        [Trait(nameof(City), "Instantiation")]
        public void City_Instantiate_NameMustNotBeEmptySpaces()
        {
            var city = Domain.Entities.City.FactoryTest(
                TestConstants.CITY_ID_VALID,
                TestConstants.CITY_NAME_INVALID_EMPTY_SPACES,
                TestConstants.ACTIVE,
                TestConstants.COUNTRY_ID_VALID,
                TestConstants.COUNTRY_VALID
                );

            var isValid = city.IsValid();

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.City.Name)} is required",
                city.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact(DisplayName = "Name must have 100 chars or less")]
        [Trait(nameof(City), "Instantiation")]
        public void City_Instantiate_NameMustHaveValidLength()
        {
            var city = Domain.Entities.City.FactoryTest(
                TestConstants.CITY_ID_VALID,
                TestConstants.CITY_NAME_VALID_LENGTH_EDGE,
                TestConstants.ACTIVE,
                TestConstants.COUNTRY_ID_VALID,
                TestConstants.COUNTRY_VALID
                );

            var isValid = city.IsValid();

            Assert.True(isValid);

            city = Domain.Entities.City.FactoryTest(
                TestConstants.CITY_ID_VALID,
                TestConstants.CITY_NAME_INVALID_LENGTH,
                TestConstants.ACTIVE,
                TestConstants.COUNTRY_ID_VALID,
                TestConstants.COUNTRY_VALID
                );

            isValid = city.IsValid();

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.City.Name)} can not have more than 100 chars",
                city.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact(DisplayName = "Country Id is required")]
        [Trait(nameof(City), "Instantiation")]
        public void City_Instantiate_CountryMustNotBeNull()
        {
            var city = Domain.Entities.City.FactoryTest(
                TestConstants.CITY_ID_VALID,
                TestConstants.CITY_NAME_VALID,
                TestConstants.ACTIVE,
                TestConstants.COUNTRY_ID_INVALID,
                TestConstants.COUNTRY_VALID
                );

            var isValid = city.IsValid();

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.City.Country)} is required",
                city.ValidationResult.Errors.Select(error => error.Message).ToList());
        }
    }
}
