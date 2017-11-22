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
                TestConstants.POSTCODE_VALID_EDGE,
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
                TestConstants.POSTCODE_VALID_EDGE,
                TestConstants.ADVENTURE_ID_VALID
                );

            var isValid = address.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Address.Street01)} is required", address.ValidationResult.Errors
                .Select(error => error.Message).ToList());
        }

        [Test]
        public void AddressStreet01MustNotBeEmpty()
        {
            var address = Domain.Entities.Address.FactoryTest(
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.STREET01_INVALID_EMPTY,
                TestConstants.COMPLEMENT_VALID,
                TestConstants.POSTCODE_VALID_EDGE,
                TestConstants.ADVENTURE_ID_VALID
                );

            var isValid = address.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Address.Street01)} is required", address.ValidationResult.Errors
                .Select(error => error.Message).ToList());
        }

        [Test]
        public void AddressStreet01MustNotBeEmptySpaces()
        {
            var address = Domain.Entities.Address.FactoryTest(
                TestConstants.ADDRESS_ID_VALID,
                TestConstants.STREET01_INVALID_EMPTY_SPACES,
                TestConstants.COMPLEMENT_VALID,
                TestConstants.POSTCODE_VALID_EDGE,
                TestConstants.ADVENTURE_ID_VALID
                );

            var isValid = address.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Address.Street01)} is required", address.ValidationResult.Errors
                .Select(error => error.Message).ToList());
        }
    }
}
