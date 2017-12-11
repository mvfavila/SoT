using AutoMoq;
using Bogus;
using Moq;
using SoT.Application.AppServices;
using SoT.Domain.Entities;
using SoT.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using Xunit;

namespace SoT.Application.Tests.AppServices
{
    public class AdventureAppServiceTest
    {
        private readonly AutoMoqer mocker;

        public AdventureAppServiceTest()
        {
            mocker = new AutoMoqer();

            HttpContext.Current = new HttpContext(
                new HttpRequest("", "http://sumofthis.com", ""),
                new HttpResponse(new StringWriter())
                );
        }

        [Fact(DisplayName = "Get Adventure with Address by Adventure Id")]
        [Trait(nameof(Adventure), "App Service")]
        public void Adventure_GetById_Sucess()
        {
            // Arrange
            var address = new Faker<Address>()
                .CustomInstantiator(a => Address.FactoryTest(
                    Guid.NewGuid(),
                    a.Address.StreetName(),
                    a.Address.StreetAddress(),
                    a.Address.ZipCode(),
                    Guid.NewGuid()
                    )).Generate();

            var adventureFaker = new Faker<Adventure>()
                .CustomInstantiator(a => Adventure.FactoryTest(
                    Guid.NewGuid(),
                    a.Commerce.ProductName(),
                    Guid.NewGuid(),
                    null,
                    Guid.NewGuid(),
                    null,
                    address.AddressId,
                    address,
                    decimal.Parse(a.Commerce.Price()),
                    Guid.NewGuid(),
                    null,
                    new List<Availability>(),
                    Guid.NewGuid(),
                    true
                    ));

            mocker.Create<AdventureAppService>();
            var adventure = adventureFaker.Generate();
            var adventureAppService = mocker.Resolve<AdventureAppService>();
            var adventureService = mocker.GetMock<IAdventureService>();
            adventureService
                .Setup(a => a.GetWithAddressById(It.IsAny<Guid>(), It.IsAny<Guid>()))
                .Returns(adventure);
            var providerId = Guid.NewGuid();
            var userId = Guid.NewGuid();

            // Act
            adventureAppService.GetById(providerId, userId);

            // Assert
            adventureService.Verify(a => a.GetWithAddressById(It.IsAny<Guid>(), It.IsAny<Guid>()), Times.Once());
        }
    }
}
