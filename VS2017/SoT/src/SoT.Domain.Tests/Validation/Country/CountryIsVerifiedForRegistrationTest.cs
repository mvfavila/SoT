using NUnit.Framework;
using SoT.Domain.Tests.Shared;
using System.Linq;

namespace SoT.Domain.Tests.Validation.Country
{
    [TestFixture]
    public class CountryIsVerifiedForRegistrationTest
    {
        [Test]
        public void CountryMustBeValid()
        {
            var country = Domain.Entities.Country.FactoryTest(
                TestConstants.COUNTRY_ID_VALID,
                TestConstants.COUNTRY_NAME_VALID,
                TestConstants.ACTIVE,
                TestConstants.REGION_ID_VALID,
                TestConstants.REGION_VALID
                );

            var isValid = country.IsValid();

            Assert.IsTrue(isValid);
            Assert.IsFalse(country.ValidationResult.Errors.Any());
        }

        [Test]
        public void CountryNameMustNotBeNull()
        {
            var country = Domain.Entities.Country.FactoryTest(
                TestConstants.COUNTRY_ID_VALID,
                TestConstants.COUNTRY_NAME_INVALID_NULL,
                TestConstants.ACTIVE,
                TestConstants.REGION_ID_VALID,
                TestConstants.REGION_VALID
                );

            var isValid = country.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Country.Name)} is required",
                country.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Test]
        public void CountryNameMustNotBeEmpty()
        {
            var country = Domain.Entities.Country.FactoryTest(
                TestConstants.COUNTRY_ID_VALID,
                TestConstants.COUNTRY_NAME_INVALID_EMPTY,
                TestConstants.ACTIVE,
                TestConstants.REGION_ID_VALID,
                TestConstants.REGION_VALID
                );

            var isValid = country.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Country.Name)} is required",
                country.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Test]
        public void CountryNameMustNotBeEmptySpaces()
        {
            var country = Domain.Entities.Country.FactoryTest(
                TestConstants.COUNTRY_ID_VALID,
                TestConstants.COUNTRY_NAME_INVALID_EMPTY_SPACES,
                TestConstants.ACTIVE,
                TestConstants.REGION_ID_VALID,
                TestConstants.REGION_VALID
                );

            var isValid = country.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Country.Name)} is required",
                country.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Test]
        public void CountryNameMustHaveValidLength()
        {
            var country = Domain.Entities.Country.FactoryTest(
                TestConstants.COUNTRY_ID_VALID,
                TestConstants.COUNTRY_NAME_VALID_LENGTH_EDGE,
                TestConstants.ACTIVE,
                TestConstants.REGION_ID_VALID,
                TestConstants.REGION_VALID
                );

            var isValid = country.IsValid();

            Assert.IsTrue(isValid);

            country = Domain.Entities.Country.FactoryTest(
                TestConstants.COUNTRY_ID_VALID,
                TestConstants.COUNTRY_NAME_INVALID_LENGTH,
                TestConstants.ACTIVE,
                TestConstants.REGION_ID_VALID,
                TestConstants.REGION_VALID
                );

            isValid = country.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Country.Name)} can not have more than 70 chars",
                country.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Test]
        public void CountryrRegionMustNotBeNull()
        {
            var country = Domain.Entities.Country.FactoryTest(
                TestConstants.COUNTRY_ID_VALID,
                TestConstants.COUNTRY_NAME_VALID,
                TestConstants.ACTIVE,
                TestConstants.REGION_ID_INVALID,
                TestConstants.REGION_VALID
                );

            var isValid = country.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Country.Region)} is required",
                country.ValidationResult.Errors.Select(error => error.Message).ToList());
        }
    }
}
