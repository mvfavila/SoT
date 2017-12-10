using SoT.Domain.Tests.Shared;
using System.Linq;
using Xunit;

namespace SoT.Domain.Tests.Validation.Region
{
    public class RegionIsVerifiedForRegistration
    {
        [Fact]
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

            Assert.True(isValid);
            Assert.False(region.ValidationResult.Errors.Any());
        }

        [Fact]
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

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Region.Name)} is required",
                region.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact]
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

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Region.Name)} is required",
                region.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact]
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

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Region.Name)} is required",
                region.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact]
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

            Assert.True(isValid);

            region = Domain.Entities.Region.FactoryTest(
                TestConstants.REGION_ID_VALID,
                TestConstants.REGION_NAME_INVALID_LENGTH,
                TestConstants.ACTIVE,
                TestConstants.CONTINENT_ID_VALID,
                TestConstants.CONTINENT_VALID
                );

            isValid = region.IsValid();

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Region.Name)} can not have more than 100 chars",
                region.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact]
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

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Region.Continent)} is required",
                region.ValidationResult.Errors.Select(error => error.Message).ToList());
        }
    }
}
