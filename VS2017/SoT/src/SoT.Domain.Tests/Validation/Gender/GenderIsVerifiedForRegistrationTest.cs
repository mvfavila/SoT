using SoT.Domain.Tests.Shared;
using System.Linq;
using Xunit;

namespace SoT.Domain.Tests.Validation.Gender
{
    public class GenderIsVerifiedForRegistrationTest
    {
        [Fact(DisplayName = "Valid instance")]
        [Trait(nameof(Gender), "Instantiation")]
        public void Gender_Instantiate_MustBeValid()
        {
            var gender = Domain.Entities.Gender.FactoryTest(
                TestConstants.GENDER_ID_VALID,
                TestConstants.GENDER_VALUE_VALID,
                TestConstants.ACTIVE
                );

            var isValid = gender.IsValid();

            Assert.True(isValid);
            Assert.False(gender.ValidationResult.Errors.Any());
        }

        [Fact(DisplayName = "Id is required")]
        [Trait(nameof(Gender), "Instantiation")]
        public void Gender_Instantiate_KeyMustNotBeNull()
        {
            var gender = Domain.Entities.Gender.FactoryTest(
                TestConstants.GENDER_ID_INVALID,
                TestConstants.GENDER_VALUE_VALID,
                TestConstants.ACTIVE
                );

            var isValid = gender.IsValid();

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Gender.GenderId)} is required",
                gender.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact(DisplayName = "Value is required (Not null)")]
        [Trait(nameof(Gender), "Instantiation")]
        public void Gender_Instantiate_NameMustNotBeNull()
        {
            var gender = Domain.Entities.Gender.FactoryTest(
                TestConstants.GENDER_ID_VALID,
                TestConstants.GENDER_VALUE_INVALID_NULL,
                TestConstants.ACTIVE
                );

            var isValid = gender.IsValid();

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Gender.Value)} is required",
                gender.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact(DisplayName = "Value is required (Not empty)")]
        [Trait(nameof(Gender), "Instantiation")]
        public void Gender_Instantiate_NameMustNotBeEmpty()
        {
            var gender = Domain.Entities.Gender.FactoryTest(
                TestConstants.GENDER_ID_VALID,
                TestConstants.GENDER_VALUE_INVALID_EMPTY,
                TestConstants.ACTIVE
                );

            var isValid = gender.IsValid();

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Gender.Value)} is required",
                gender.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact(DisplayName = "Value is required (Not empty spaces)")]
        [Trait(nameof(Gender), "Instantiation")]
        public void Gender_Instantiate_NameMustNotBeEmptySpaces()
        {
            var gender = Domain.Entities.Gender.FactoryTest(
                 TestConstants.GENDER_ID_VALID,
                 TestConstants.GENDER_VALUE_INVALID_EMPTY_SPACES,
                 TestConstants.ACTIVE
                 );

            var isValid = gender.IsValid();

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Gender.Value)} is required",
                gender.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact(DisplayName = "Value must have 30 chars or less")]
        [Trait(nameof(Gender), "Instantiation")]
        public void Gender_Instantiate_NameMustHaveValidLength()
        {
            var gender = Domain.Entities.Gender.FactoryTest(
                TestConstants.GENDER_ID_VALID,
                TestConstants.GENDER_VALUE_VALID_LENGTH_EDGE,
                TestConstants.ACTIVE
                );

            var isValid = gender.IsValid();

            Assert.True(isValid);

            gender = Domain.Entities.Gender.FactoryTest(
                TestConstants.GENDER_ID_VALID,
                TestConstants.GENDER_VALUE_INVALID_LENGTH,
                TestConstants.ACTIVE
                );

            isValid = gender.IsValid();

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Gender.Value)} can not have more than 30 chars",
                gender.ValidationResult.Errors.Select(error => error.Message).ToList());
        }
    }
}
