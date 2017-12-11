using AutoMoq;
using Bogus;
using Moq;
using SoT.Domain.Entities;
using SoT.Domain.Interfaces.Repository;
using SoT.Domain.Interfaces.Repository.ReadOnly;
using SoT.Domain.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace SoT.Domain.Tests.Services
{
    public class ProviderServiceTest
    {
        private readonly AutoMoqer mocker;

        public ProviderServiceTest()
        {
            mocker = new AutoMoqer();
        }

        [Fact(DisplayName = "Get Provider and Employee by Provider Id")]
        [Trait(nameof(Provider), "Domain Service")]
        public void Provider_GetWithEmployeeById_Sucess()
        {
            // Arrange
            mocker.Create<ProviderService>();

            var providerService = mocker.Resolve<ProviderService>();
            var providerRepository = mocker.GetMock<IProviderReadOnlyRepository>();
            var providerId = Guid.NewGuid();

            // Act
            providerService.GetWithEmployeeById(providerId);

            // Assert
            providerRepository.Verify(c => c.GetWithEmployeeById(It.IsAny<Guid>()), Times.Once());
        }

        [Fact(DisplayName = "Add Provider Sucess")]
        [Trait(nameof(Provider), "Domain Service")]
        public void Provider_Add_Sucess()
        {
            // Arrange
            mocker.Create<ProviderService>();

            var providerService = mocker.Resolve<ProviderService>();
            var providerRepository = mocker.GetMock<IProviderRepository>();

            var providerFaker = new Faker<Provider>()
                .CustomInstantiator(p => Provider.FactoryTest(
                    Guid.NewGuid(),
                    p.Company.CompanyName(),
                    new List<Adventure>(),
                    new List<Employee>(),
                    true
                    ));

            var provider = providerFaker.Generate();

            // Act
            var validationResult = providerService.Add(provider);

            // Assert
            providerRepository.Verify(e => e.Add(provider), Times.Once());
            Assert.True(validationResult.IsValid);
            Assert.Empty(validationResult.Errors);
        }

        [Fact(DisplayName = "Update Provider Sucess")]
        [Trait(nameof(Provider), "Domain Service")]
        public void Provider_Update_Sucess()
        {
            // Arrange
            mocker.Create<ProviderService>();

            var providerService = mocker.Resolve<ProviderService>();
            var providerRepository = mocker.GetMock<IProviderRepository>();

            var providerFaker = new Faker<Provider>()
                .CustomInstantiator(p => Provider.FactoryTest(
                    Guid.NewGuid(),
                    p.Company.CompanyName(),
                    new List<Adventure>(),
                    new List<Employee>(),
                    true
                    ));

            var provider = providerFaker.Generate();

            // Act
            var validationResult = providerService.Update(provider);

            // Assert
            providerRepository.Verify(e => e.Update(provider), Times.Once());
            Assert.True(validationResult.IsValid);
            Assert.Empty(validationResult.Errors);
        }
    }
}
