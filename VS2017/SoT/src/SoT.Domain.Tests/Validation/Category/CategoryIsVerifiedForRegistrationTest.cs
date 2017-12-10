using SoT.Domain.Tests.Shared;
using System.Linq;
using Xunit;

namespace SoT.Domain.Tests.Validation.Category
{
    public class CategoryIsVerifiedForRegistrationTest
    {
        [Fact]
        public void Category_Instantiate_MustBeValid()
        {
            var category = Domain.Entities.Category.FactoryTest(
                TestConstants.CATEGORY_ID_VALID,
                TestConstants.CATEGORY_NAME_VALID,
                TestConstants.ACTIVE,
                TestConstants.ELEMENT_ID_VALID,
                TestConstants.ELEMENT_VALID
                );

            var isValid = category.IsValid();

            Assert.True(isValid);
            Assert.False(category.ValidationResult.Errors.Any());
        }

        [Fact]
        public void Category_Instantiate_KeyMustNotBeNull()
        {
            var category = Domain.Entities.Category.FactoryTest(
                TestConstants.CATEGORY_ID_INVALID,
                TestConstants.CATEGORY_NAME_VALID,
                TestConstants.ACTIVE,
                TestConstants.ELEMENT_ID_VALID,
                TestConstants.ELEMENT_VALID
                );

            var isValid = category.IsValid();

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Category.CategoryId)} is required",
                category.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact]
        public void Category_Instantiate_NameMustNotBeNull()
        {
            var category = Domain.Entities.Category.FactoryTest(
                TestConstants.CATEGORY_ID_VALID,
                TestConstants.CATEGORY_NAME_INVALID_NULL,
                TestConstants.ACTIVE,
                TestConstants.ELEMENT_ID_VALID,
                TestConstants.ELEMENT_VALID
                );

            var isValid = category.IsValid();

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Category.Name)} is required",
                category.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact]
        public void Category_Instantiate_NameMustNotBeEmpty()
        {
            var category = Domain.Entities.Category.FactoryTest(
                TestConstants.CATEGORY_ID_VALID,
                TestConstants.CATEGORY_NAME_INVALID_EMPTY,
                TestConstants.ACTIVE,
                TestConstants.ELEMENT_ID_VALID,
                TestConstants.ELEMENT_VALID
                );

            var isValid = category.IsValid();

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Category.Name)} is required",
                category.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact]
        public void Category_Instantiate_NameMustNotBeEmptySpaces()
        {
            var category = Domain.Entities.Category.FactoryTest(
                TestConstants.CATEGORY_ID_VALID,
                TestConstants.CATEGORY_NAME_INVALID_EMPTY_SPACES,
                TestConstants.ACTIVE,
                TestConstants.ELEMENT_ID_VALID,
                TestConstants.ELEMENT_VALID
                );

            var isValid = category.IsValid();

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Category.Name)} is required",
                category.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact]
        public void Category_Instantiate_NameMustHaveValidLength()
        {
            var category = Domain.Entities.Category.FactoryTest(
                TestConstants.CATEGORY_ID_VALID,
                TestConstants.CATEGORY_NAME_VALID_LENGTH_EDGE,
                TestConstants.ACTIVE,
                TestConstants.ELEMENT_ID_VALID,
                TestConstants.ELEMENT_VALID
                );

            var isValid = category.IsValid();

            Assert.True(isValid);

            category = Domain.Entities.Category.FactoryTest(
                TestConstants.CATEGORY_ID_VALID,
                TestConstants.CATEGORY_NAME_INVALID_LENGTH,
                TestConstants.ACTIVE,
                TestConstants.ELEMENT_ID_VALID,
                TestConstants.ELEMENT_VALID
                );

            isValid = category.IsValid();

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Category.Name)} can not have more than 100 chars",
                category.ValidationResult.Errors.Select(error => error.Message).ToList());
        }
    }
}
