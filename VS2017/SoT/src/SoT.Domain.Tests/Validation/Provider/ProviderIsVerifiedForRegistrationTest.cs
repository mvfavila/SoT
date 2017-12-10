﻿using SoT.Domain.Tests.Shared;
using System.Linq;
using Xunit;

namespace SoT.Domain.Tests.Validation.Provider
{
    public class ProviderIsVerifiedForRegistrationTest
    {
        [Fact]
        public void ProviderMustBeValid()
        {
            var provider = Domain.Entities.Provider.FactoryTest(
                TestConstants.PROVIDER_ID_VALID,
                TestConstants.PROVIDER_COMPANY_NAME_VALID,
                TestConstants.PROVIDER_ADVENTURES_VALID,
                TestConstants.PROVIDER_EMPLOYEES_VALID,
                TestConstants.ACTIVE
                );

            var isValid = provider.IsValid();

            Assert.True(isValid);
            Assert.False(provider.ValidationResult.Errors.Any());
        }

        [Fact]
        public void ProviderIdMustNotBeNull()
        {
            var provider = Domain.Entities.Provider.FactoryTest(
                TestConstants.PROVIDER_ID_INVALID,
                TestConstants.PROVIDER_COMPANY_NAME_VALID,
                TestConstants.PROVIDER_ADVENTURES_VALID,
                TestConstants.PROVIDER_EMPLOYEES_VALID,
                TestConstants.ACTIVE
                );

            var isValid = provider.IsValid();

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Provider.ProviderId)} is required",
                provider.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact]
        public void ProviderCompanyNameMustNotBeNull()
        {
            var provider = Domain.Entities.Provider.FactoryTest(
                TestConstants.PROVIDER_ID_VALID,
                TestConstants.PROVIDER_COMPANY_NAME_INVALID_NULL,
                TestConstants.PROVIDER_ADVENTURES_VALID,
                TestConstants.PROVIDER_EMPLOYEES_VALID,
                TestConstants.ACTIVE
                );

            var isValid = provider.IsValid();

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Provider.CompanyName)} is required",
                provider.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact]
        public void ProviderCompanyNameMustNotBeEmpty()
        {
            var provider = Domain.Entities.Provider.FactoryTest(
                TestConstants.PROVIDER_ID_VALID,
                TestConstants.PROVIDER_COMPANY_NAME_INVALID_EMPTY,
                TestConstants.PROVIDER_ADVENTURES_VALID,
                TestConstants.PROVIDER_EMPLOYEES_VALID,
                TestConstants.ACTIVE
                );

            var isValid = provider.IsValid();

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Provider.CompanyName)} is required",
                provider.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact]
        public void ProviderCompanyNameMustNotBeEmptySpaces()
        {
            var provider = Domain.Entities.Provider.FactoryTest(
                TestConstants.PROVIDER_ID_VALID,
                TestConstants.PROVIDER_COMPANY_NAME_INVALID_EMPTY_SPACES,
                TestConstants.PROVIDER_ADVENTURES_VALID,
                TestConstants.PROVIDER_EMPLOYEES_VALID,
                TestConstants.ACTIVE
                );

            var isValid = provider.IsValid();

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Provider.CompanyName)} is required",
                provider.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact]
        public void ProviderCompanyNameMustHaveValidLength()
        {
            var provider = Domain.Entities.Provider.FactoryTest(
                TestConstants.PROVIDER_ID_VALID,
                TestConstants.PROVIDER_COMPANY_NAME_VALID_LENGTH_EDGE,
                TestConstants.PROVIDER_ADVENTURES_VALID,
                TestConstants.PROVIDER_EMPLOYEES_VALID,
                TestConstants.ACTIVE
                );

            var isValid = provider.IsValid();

            Assert.True(isValid);

            provider = Domain.Entities.Provider.FactoryTest(
                TestConstants.PROVIDER_ID_VALID,
                TestConstants.PROVIDER_COMPANY_NAME_INVALID_LENGTH,
                TestConstants.PROVIDER_ADVENTURES_VALID,
                TestConstants.PROVIDER_EMPLOYEES_VALID,
                TestConstants.ACTIVE
                );

            isValid = provider.IsValid();

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Provider.CompanyName)} can not have more than 400 chars",
                provider.ValidationResult.Errors.Select(error => error.Message).ToList());
        }
    }
}
