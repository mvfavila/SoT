using NUnit.Framework;
using SoT.Domain.Tests.Shared;
using System.Linq;

namespace SoT.Domain.Tests.Validation.Region
{
    [TestFixture]
    public class RegionIsVerifiedForRegistration
    {
        [Test]
        public void RegionMustBeValid()
        {
            var region = Domain.Entities.Region.FactoryTest(
                TestConstants.REGION_ID_VALID,
                TestConstants.REGION_NAME_VALID,
                TestConstants.ACTIVE,
                TestConstants.CONTINENT_ID_VALID,
                TestConstants.CONTINENT_VALID
                );

            var isValid = region.IsValid();

            Assert.IsTrue(isValid);
            Assert.IsFalse(region.ValidationResult.Errors.Any());
        }

        [Test]
        public void RegionNameMustNotBeNull()
        {
            var region = Domain.Entities.Region.FactoryTest(
                TestConstants.REGION_ID_VALID,
                TestConstants.REGION_NAME_INVALID_NULL,
                TestConstants.ACTIVE,
                TestConstants.CONTINENT_ID_VALID,
                TestConstants.CONTINENT_VALID
                );

            var isValid = region.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Region.Name)} is required",
                region.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Test]
        public void RegionNameMustNotBeEmpty()
        {
            var region = Domain.Entities.Region.FactoryTest(
                TestConstants.REGION_ID_VALID,
                TestConstants.REGION_NAME_INVALID_EMPTY,
                TestConstants.ACTIVE,
                TestConstants.CONTINENT_ID_VALID,
                TestConstants.CONTINENT_VALID
                );

            var isValid = region.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Region.Name)} is required",
                region.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Test]
        public void RegionNameMustNotBeEmptySpaces()
        {
            var region = Domain.Entities.Region.FactoryTest(
                TestConstants.REGION_ID_VALID,
                TestConstants.REGION_NAME_INVALID_EMPTY_SPACES,
                TestConstants.ACTIVE,
                TestConstants.CONTINENT_ID_VALID,
                TestConstants.CONTINENT_VALID
                );

            var isValid = region.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Region.Name)} is required",
                region.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Test]
        public void RegionNameMustHaveValidLength()
        {
            var region = Domain.Entities.Region.FactoryTest(
                TestConstants.REGION_ID_VALID,
                TestConstants.REGION_NAME_VALID_LENGTH_EDGE,
                TestConstants.ACTIVE,
                TestConstants.CONTINENT_ID_VALID,
                TestConstants.CONTINENT_VALID
                );

            var isValid = region.IsValid();

            Assert.IsTrue(isValid);

            region = Domain.Entities.Region.FactoryTest(
                TestConstants.REGION_ID_VALID,
                TestConstants.REGION_NAME_INVALID_LENGTH,
                TestConstants.ACTIVE,
                TestConstants.CONTINENT_ID_VALID,
                TestConstants.CONTINENT_VALID
                );

            isValid = region.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Region.Name)} can not have more than 100 chars",
                region.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Test]
        public void RegionContinentMustNotBeNull()
        {
            var region = Domain.Entities.Region.FactoryTest(
                TestConstants.REGION_ID_VALID,
                TestConstants.REGION_NAME_VALID,
                TestConstants.ACTIVE,
                TestConstants.CONTINENT_ID_INVALID,
                TestConstants.CONTINENT_VALID
                );

            var isValid = region.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Region.Continent)} is required",
                region.ValidationResult.Errors.Select(error => error.Message).ToList());
        }
    }
}
