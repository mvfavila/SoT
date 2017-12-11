using AutoMoq;
using Bogus;
using Moq;
using SoT.Domain.Entities;
using SoT.Domain.Interfaces.Repository;
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
    }
}
