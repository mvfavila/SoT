using SoT.Domain.Tests.Shared;
using System.Linq;
using Xunit;

namespace SoT.Domain.Tests.Validation.Address
{
    public class AddressValidationTest
    {
        [Fact(DisplayName = "Valid instance")]
        [Trait(nameof(Address), "Instantiation")]
        public void Address_Instantiate_MustBeValid()
        {
            var address = Domain.Entities.Address.FactoryTest(
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.STREET01_VALID,
                TestConstants.COMPLEMENT_VALID,
                TestConstants.POSTCODE_VALID,
                TestConstants.ADVENTURE_ID_VALID
                );

            var isValid = address.IsValid();

            Assert.True(isValid);
            Assert.False(address.ValidationResult.Errors.Any());
        }

        [Fact(DisplayName = "Id is required")]
        [Trait(nameof(Address), "Instantiation")]
        public void Address_Instantiate_KeyMustNotBeNull()
        {
            var address = Domain.Entities.Address.FactoryTest(
                TestConstants.ADDRESS_ID_INVALID,
                TestConstants.STREET01_VALID,
                TestConstants.COMPLEMENT_VALID,
                TestConstants.POSTCODE_VALID,
                TestConstants.ADVENTURE_ID_VALID
                );

            var isValid = address.IsValid();

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Address.AddressId)} is required",
                address.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact(DisplayName = "Street01 is required (Not null)")]
        [Trait(nameof(Address), "Instantiation")]
        public void Address_Instantiate_Street01MustNotBeNull()
        {
            var address = Domain.Entities.Address.FactoryTest(
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.STREET01_INVALID_NULL,
                TestConstants.COMPLEMENT_VALID,
                TestConstants.POSTCODE_VALID,
                TestConstants.ADVENTURE_ID_VALID
                );

            var isValid = address.IsValid();

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Address.Street01)} is required",
                address.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact(DisplayName = "Street01 is required (Not empty)")]
        [Trait(nameof(Address), "Instantiation")]
        public void Address_Instantiate_Street01MustNotBeEmpty()
        {
            var address = Domain.Entities.Address.FactoryTest(
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.STREET01_INVALID_EMPTY,
                TestConstants.COMPLEMENT_VALID,
                TestConstants.POSTCODE_VALID,
                TestConstants.ADVENTURE_ID_VALID
                );

            var isValid = address.IsValid();

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Address.Street01)} is required",
                address.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact(DisplayName = "Street01 is required (Not empty spaces)")]
        [Trait(nameof(Address), "Instantiation")]
        public void Address_Instantiate_Street01MustNotBeEmptySpaces()
        {
            var address = Domain.Entities.Address.FactoryTest(
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.STREET01_INVALID_EMPTY_SPACES,
                TestConstants.COMPLEMENT_VALID,
                TestConstants.POSTCODE_VALID,
                TestConstants.ADVENTURE_ID_VALID
                );

            var isValid = address.IsValid();

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Address.Street01)} is required",
                address.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact(DisplayName = "Street01 must have 300 chars or less")]
        [Trait(nameof(Address), "Instantiation")]
        public void Address_Instantiate_Street01MustHaveValidLength()
        {
            var address = Domain.Entities.Address.FactoryTest(
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.STREET01_VALID_LENGTH_EDGE,
                TestConstants.COMPLEMENT_VALID,
                TestConstants.POSTCODE_VALID,
                TestConstants.ADVENTURE_ID_VALID
                );

            var isValid = address.IsValid();

            Assert.True(isValid);

            address = Domain.Entities.Address.FactoryTest(
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.STREET01_INVALID_LENGTH,
                TestConstants.COMPLEMENT_VALID,
                TestConstants.POSTCODE_VALID,
                TestConstants.ADVENTURE_ID_VALID
                );

            isValid = address.IsValid();

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Address.Street01)} can not have more than 300 chars",
                address.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact(DisplayName = "Complement must have 300 chars or less")]
        [Trait(nameof(Address), "Instantiation")]
        public void Address_Instantiate_ComplementMustHaveValidLength()
        {
            var address = Domain.Entities.Address.FactoryTest(
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.STREET01_VALID,
                TestConstants.COMPLEMENT_VALID_LENGTH_EDGE,
                TestConstants.POSTCODE_VALID,
                TestConstants.ADVENTURE_ID_VALID
                );

            var isValid = address.IsValid();

            Assert.True(isValid);

            address = Domain.Entities.Address.FactoryTest(
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.STREET01_VALID,
                TestConstants.COMPLEMENT_INVALID_LENGTH,
                TestConstants.POSTCODE_VALID,
                TestConstants.ADVENTURE_ID_VALID
                );

            isValid = address.IsValid();

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Address.Complement)} can not have more than 300 chars",
                address.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact(DisplayName = "Complement must accept null")]
        [Trait(nameof(Address), "Instantiation")]
        public void Address_Instantiate_ComplementMustBeValidOptional()
        {
            var address = Domain.Entities.Address.FactoryTest(
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.STREET01_VALID,
                TestConstants.COMPLEMENT_VALID_NULL,
                TestConstants.POSTCODE_VALID,
                TestConstants.ADVENTURE_ID_VALID
                );

            var isValid = address.IsValid();

            Assert.True(isValid);
        }

        [Fact(DisplayName = "Postcode must have 30 chars or less")]
        [Trait(nameof(Address), "Instantiation")]
        public void Address_Instantiate_PostcodeMustHaveValidLength()
        {
            var address = Domain.Entities.Address.FactoryTest(
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.STREET01_VALID,
                TestConstants.COMPLEMENT_VALID,
                TestConstants.POSTCODE_VALID_EDGE,
                TestConstants.ADVENTURE_ID_VALID
                );

            var isValid = address.IsValid();

            Assert.True(isValid);

            address = Domain.Entities.Address.FactoryTest(
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.STREET01_VALID,
                TestConstants.COMPLEMENT_VALID,
                TestConstants.POSTCODE_INVALID_LENGTH,
                TestConstants.ADVENTURE_ID_VALID
                );

            isValid = address.IsValid();

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Address.Postcode)} can not have more than 30 chars",
                address.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact(DisplayName = "Postcode must accept null")]
        [Trait(nameof(Address), "Instantiation")]
        public void Address_Instantiate_PostcodeMustBeValidOptional()
        {
            var address = Domain.Entities.Address.FactoryTest(
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.STREET01_VALID,
                TestConstants.COMPLEMENT_VALID,
                TestConstants.POSTCODE_VALID_NULL,
                TestConstants.ADVENTURE_ID_VALID
                );

            var isValid = address.IsValid();

            Assert.True(isValid);
        }

        [Fact(DisplayName = "Adventure Id is required")]
        [Trait(nameof(Address), "Instantiation")]
        public void Address_Instantiate_AdventureIdMustNotBeEmpty()
        {
            var address = Domain.Entities.Address.FactoryTest(
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.STREET01_VALID,
                TestConstants.COMPLEMENT_VALID,
                TestConstants.POSTCODE_VALID,
                TestConstants.ADVENTURE_ID_INVALID
                );

            var isValid = address.IsValid();

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Address.AdventureId)} is required",
                address.ValidationResult.Errors.Select(error => error.Message).ToList());
        }
    }
}
