using NUnit.Framework;
using SoT.Domain.Tests.Shared;
using System.Linq;

namespace SoT.Domain.Tests.Validation.Category
{
    [TestFixture]
    public class CategoryIsVerifiedForRegistrationTest
    {
        [Test]
        public void CategoryMustBeValid()
        {
            var category = Domain.Entities.Category.FactoryTest(
                TestConstants.CATEGORY_ID_VALID,
                TestConstants.CATEGORY_NAME_VALID,
                TestConstants.ACTIVE,
                TestConstants.ELEMENT_ID_VALID,
                TestConstants.ELEMENT_VALID
                );

            var isValid = category.IsValid();

            Assert.IsTrue(isValid);
            Assert.IsFalse(category.ValidationResult.Errors.Any());
        }

        [Test]
        public void CategoryKeyMustNotBeNull()
        {
            var category = Domain.Entities.Category.FactoryTest(
                TestConstants.CATEGORY_ID_INVALID,
                TestConstants.CATEGORY_NAME_VALID,
                TestConstants.ACTIVE,
                TestConstants.ELEMENT_ID_VALID,
                TestConstants.ELEMENT_VALID
                );

            var isValid = category.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Category.CategoryId)} is required",
                category.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Test]
        public void CategoryNameMustNotBeNull()
        {
            var category = Domain.Entities.Category.FactoryTest(
                TestConstants.CATEGORY_ID_VALID,
                TestConstants.CATEGORY_NAME_INVALID_NULL,
                TestConstants.ACTIVE,
                TestConstants.ELEMENT_ID_VALID,
                TestConstants.ELEMENT_VALID
                );

            var isValid = category.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Category.Name)} is required",
                category.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Test]
        public void CategoryNameMustNotBeEmpty()
        {
            var category = Domain.Entities.Category.FactoryTest(
                TestConstants.CATEGORY_ID_VALID,
                TestConstants.CATEGORY_NAME_INVALID_EMPTY,
                TestConstants.ACTIVE,
                TestConstants.ELEMENT_ID_VALID,
                TestConstants.ELEMENT_VALID
                );

            var isValid = category.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Category.Name)} is required",
                category.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Test]
        public void CategoryNameMustNotBeEmptySpaces()
        {
            var category = Domain.Entities.Category.FactoryTest(
                TestConstants.CATEGORY_ID_VALID,
                TestConstants.CATEGORY_NAME_INVALID_EMPTY_SPACES,
                TestConstants.ACTIVE,
                TestConstants.ELEMENT_ID_VALID,
                TestConstants.ELEMENT_VALID
                );

            var isValid = category.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Category.Name)} is required",
                category.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Test]
        public void CategoryNameMustHaveValidLength()
        {
            var category = Domain.Entities.Category.FactoryTest(
                TestConstants.CATEGORY_ID_VALID,
                TestConstants.CATEGORY_NAME_VALID_LENGTH_EDGE,
                TestConstants.ACTIVE,
                TestConstants.ELEMENT_ID_VALID,
                TestConstants.ELEMENT_VALID
                );

            var isValid = category.IsValid();

            Assert.IsTrue(isValid);

            category = Domain.Entities.Category.FactoryTest(
                TestConstants.CATEGORY_ID_VALID,
                TestConstants.CATEGORY_NAME_INVALID_LENGTH,
                TestConstants.ACTIVE,
                TestConstants.ELEMENT_ID_VALID,
                TestConstants.ELEMENT_VALID
                );

            isValid = category.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Category.Name)} can not have more than 100 chars",
                category.ValidationResult.Errors.Select(error => error.Message).ToList());
        }
    }
}
