using NUnit.Framework;
using SoT.Domain.Tests.Shared;
using System.Linq;

namespace SoT.Domain.Tests.Validation.Address
{
    [TestFixture]
    public class AddressValidationTest
    {
        [Test]
        public void AddressMustBeValid()
        {
            var address = Domain.Entities.Address.FactoryTest(
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.STREET01_VALID,
                TestConstants.COMPLEMENT_VALID,
                TestConstants.POSTCODE_VALID,
                TestConstants.ADVENTURE_ID_VALID
                );

            var isValid = address.IsValid();

            Assert.IsTrue(isValid);
            Assert.IsFalse(address.ValidationResult.Errors.Any());
        }

        [Test]
        public void AddressStreet01MustNotBeNull()
        {
            var address = Domain.Entities.Address.FactoryTest(
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.STREET01_INVALID_NULL,
                TestConstants.COMPLEMENT_VALID,
                TestConstants.POSTCODE_VALID,
                TestConstants.ADVENTURE_ID_VALID
                );

            var isValid = address.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Address.Street01)} is required",
                address.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Test]
        public void AddressStreet01MustNotBeEmpty()
        {
            var address = Domain.Entities.Address.FactoryTest(
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.STREET01_INVALID_EMPTY,
                TestConstants.COMPLEMENT_VALID,
                TestConstants.POSTCODE_VALID,
                TestConstants.ADVENTURE_ID_VALID
                );

            var isValid = address.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Address.Street01)} is required",
                address.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Test]
        public void AddressStreet01MustNotBeEmptySpaces()
        {
            var address = Domain.Entities.Address.FactoryTest(
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.STREET01_INVALID_EMPTY_SPACES,
                TestConstants.COMPLEMENT_VALID,
                TestConstants.POSTCODE_VALID,
                TestConstants.ADVENTURE_ID_VALID
                );

            var isValid = address.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Address.Street01)} is required",
                address.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Test]
        public void AddressStreet01MustHaveValidLength()
        {
            var address = Domain.Entities.Address.FactoryTest(
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.STREET01_VALID_LENGTH_EDGE,
                TestConstants.COMPLEMENT_VALID,
                TestConstants.POSTCODE_VALID,
                TestConstants.ADVENTURE_ID_VALID
                );

            var isValid = address.IsValid();

            Assert.IsTrue(isValid);

            address = Domain.Entities.Address.FactoryTest(
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.STREET01_INVALID_LENGTH,
                TestConstants.COMPLEMENT_VALID,
                TestConstants.POSTCODE_VALID,
                TestConstants.ADVENTURE_ID_VALID
                );

            isValid = address.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Address.Street01)} can not have more than 300 chars",
                address.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Test]
        public void AddressComplementMustHaveValidLength()
        {
            var address = Domain.Entities.Address.FactoryTest(
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.STREET01_VALID,
                TestConstants.COMPLEMENT_VALID_LENGTH_EDGE,
                TestConstants.POSTCODE_VALID,
                TestConstants.ADVENTURE_ID_VALID
                );

            var isValid = address.IsValid();

            Assert.IsTrue(isValid);

            address = Domain.Entities.Address.FactoryTest(
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.STREET01_VALID,
                TestConstants.COMPLEMENT_INVALID_LENGTH,
                TestConstants.POSTCODE_VALID,
                TestConstants.ADVENTURE_ID_VALID
                );

            isValid = address.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Address.Complement)} can not have more than 300 chars",
                address.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Test]
        public void AddressComplementMustBeValidOptional()
        {
            var address = Domain.Entities.Address.FactoryTest(
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.STREET01_VALID,
                TestConstants.COMPLEMENT_VALID_NULL,
                TestConstants.POSTCODE_VALID,
                TestConstants.ADVENTURE_ID_VALID
                );

            var isValid = address.IsValid();
        }

        [Test]
        public void AddressPostcodeMustHaveValidLength()
        {
            var address = Domain.Entities.Address.FactoryTest(
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.STREET01_VALID,
                TestConstants.COMPLEMENT_VALID,
                TestConstants.POSTCODE_VALID_EDGE,
                TestConstants.ADVENTURE_ID_VALID
                );

            var isValid = address.IsValid();

            Assert.IsTrue(isValid);

            address = Domain.Entities.Address.FactoryTest(
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.STREET01_VALID,
                TestConstants.COMPLEMENT_VALID,
                TestConstants.POSTCODE_INVALID_LENGTH,
                TestConstants.ADVENTURE_ID_VALID
                );

            isValid = address.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Address.Postcode)} can not have more than 30 chars",
                address.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Test]
        public void AddressPostcodeMustBeValidOptional()
        {
            var address = Domain.Entities.Address.FactoryTest(
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.STREET01_VALID,
                TestConstants.COMPLEMENT_VALID,
                TestConstants.POSTCODE_VALID_NULL,
                TestConstants.ADVENTURE_ID_VALID
                );

            var isValid = address.IsValid();
        }
    }
}
