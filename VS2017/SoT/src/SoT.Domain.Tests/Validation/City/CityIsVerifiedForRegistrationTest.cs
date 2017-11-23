using NUnit.Framework;
using SoT.Domain.Tests.Shared;
using System.Linq;

namespace SoT.Domain.Tests.Validation.City
{
    [TestFixture]
    public class CityIsVerifiedForRegistrationTest
    {
        [Test]
        public void CityMustBeValid()
        {
            var city = Domain.Entities.City.FactoryTest(
                TestConstants.CITY_ID_VALID,
                TestConstants.CITY_NAME_VALID,
                TestConstants.ACTIVE,
                TestConstants.COUNTRY_ID_VALID,
                TestConstants.COUNTRY_VALID
                );

            var isValid = city.IsValid();

            Assert.IsTrue(isValid);
            Assert.IsFalse(city.ValidationResult.Errors.Any());
        }

        [Test]
        public void CityNameMustNotBeNull()
        {
            var city = Domain.Entities.City.FactoryTest(
                TestConstants.CITY_ID_VALID,
                TestConstants.CITY_NAME_INVALID_NULL,
                TestConstants.ACTIVE,
                TestConstants.COUNTRY_ID_VALID,
                TestConstants.COUNTRY_VALID
                );

            var isValid = city.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains($"{nameof(Domain.Entities.City.Name)} is required",
                city.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Test]
        public void CityNameMustNotBeEmpty()
        {
            var city = Domain.Entities.City.FactoryTest(
                TestConstants.CITY_ID_VALID,
                TestConstants.CITY_NAME_INVALID_EMPTY,
                TestConstants.ACTIVE,
                TestConstants.COUNTRY_ID_VALID,
                TestConstants.COUNTRY_VALID
                );

            var isValid = city.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains($"{nameof(Domain.Entities.City.Name)} is required",
                city.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Test]
        public void CityNameMustNotBeEmptySpaces()
        {
            var city = Domain.Entities.City.FactoryTest(
                TestConstants.CITY_ID_VALID,
                TestConstants.CITY_NAME_INVALID_EMPTY_SPACES,
                TestConstants.ACTIVE,
                TestConstants.COUNTRY_ID_VALID,
                TestConstants.COUNTRY_VALID
                );

            var isValid = city.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains($"{nameof(Domain.Entities.City.Name)} is required",
                city.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Test]
        public void CityNameMustHaveValidLength()
        {
            var city = Domain.Entities.City.FactoryTest(
                TestConstants.CITY_ID_VALID,
                TestConstants.CITY_NAME_VALID_LENGTH_EDGE,
                TestConstants.ACTIVE,
                TestConstants.COUNTRY_ID_VALID,
                TestConstants.COUNTRY_VALID
                );

            var isValid = city.IsValid();

            Assert.IsTrue(isValid);

            city = Domain.Entities.City.FactoryTest(
                TestConstants.CITY_ID_VALID,
                TestConstants.CITY_NAME_INVALID_LENGTH,
                TestConstants.ACTIVE,
                TestConstants.COUNTRY_ID_VALID,
                TestConstants.COUNTRY_VALID
                );

            isValid = city.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains($"{nameof(Domain.Entities.City.Name)} can not have more than 100 chars",
                city.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Test]
        public void CItyCountryMustNotBeNull()
        {
            var city = Domain.Entities.City.FactoryTest(
                TestConstants.CITY_ID_VALID,
                TestConstants.CITY_NAME_VALID,
                TestConstants.ACTIVE,
                TestConstants.COUNTRY_ID_INVALID,
                TestConstants.COUNTRY_VALID
                );

            var isValid = city.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains($"{nameof(Domain.Entities.City.Country)} is required",
                city.ValidationResult.Errors.Select(error => error.Message).ToList());
        }
    }
}
