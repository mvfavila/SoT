using SoT.Domain.Tests.Shared;
using System.Linq;
using Xunit;

namespace SoT.Domain.Tests.Validation.Region
{
    public class RegionIsVerifiedForRegistration
    {
        [Fact(DisplayName = "Valid instance")]
        [Trait(nameof(Region), "Instantiation")]
        public void Region_Instantiate_MustBeValid()
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

        [Fact(DisplayName = "Id is required")]
        [Trait(nameof(Region), "Instantiation")]
        public void Region_Instantiate_KeyMustNotBeNull()
        {
            var region = Domain.Entities.Region.FactoryTest(
                TestConstants.REGION_ID_INVALID,
                TestConstants.REGION_NAME_VALID,
                TestConstants.ACTIVE,
                TestConstants.CONTINENT_ID_VALID,
                TestConstants.CONTINENT_VALID
                );

            var isValid = region.IsValid();

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Region.RegionId)} is required",
                region.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact(DisplayName = "Name is required (Not null)")]
        [Trait(nameof(Region), "Instantiation")]
        public void Region_Instantiate_NameMustNotBeNull()
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

        [Fact(DisplayName = "Name is required (Not empty)")]
        [Trait(nameof(Region), "Instantiation")]
        public void Region_Instantiate_NameMustNotBeEmpty()
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

        [Fact(DisplayName = "Name is required (Not empty spaces)")]
        [Trait(nameof(Region), "Instantiation")]
        public void Region_Instantiate_NameMustNotBeEmptySpaces()
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

        [Fact(DisplayName = "Name must have 100 chars or less")]
        [Trait(nameof(Region), "Instantiation")]
        public void Region_Instantiate_NameMustHaveValidLength()
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

        [Fact(DisplayName = "Continent Id is required")]
        [Trait(nameof(Region), "Instantiation")]
        public void Region_Instantiate_ContinentMustNotBeNull()
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
