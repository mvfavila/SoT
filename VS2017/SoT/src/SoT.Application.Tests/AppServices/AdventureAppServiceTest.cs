using AutoMoq;
using Bogus;
using Moq;
using SoT.Application.AppServices;
using SoT.Domain.Entities;
using SoT.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            var adventure = new Faker<Adventure>()
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
                    true
                    )).Generate();

            mocker.Create<AdventureAppService>();
            var adventureAppService = mocker.Resolve<AdventureAppService>();
            var adventureService = mocker.GetMock<IAdventureService>();
            adventureService
                .Setup(a => a.GetWithAddressById(It.IsAny<Guid>(), It.IsAny<Guid>()))
                .Returns(adventure);
            var providerId = Guid.NewGuid();
            var userId = Guid.NewGuid();

            // Act
            var adventureAddressViewModel = adventureAppService.GetById(providerId, userId);

            // Assert
            adventureService.Verify(a => a.GetWithAddressById(It.IsAny<Guid>(), It.IsAny<Guid>()), Times.Once());
            Assert.Equal(adventure.AdventureId, adventureAddressViewModel.AdventureId);
            Assert.Equal(adventure.Name, adventureAddressViewModel.Name);
            Assert.Equal(adventure.CategoryId, adventureAddressViewModel.CategoryId);
            Assert.Equal(adventure.CityId, adventureAddressViewModel.CityId);
            Assert.Equal(adventure.AddressId, adventureAddressViewModel.AddressId);
            Assert.Equal(adventure.Address.Street01, adventureAddressViewModel.Street01);
            Assert.Equal(adventure.Address.Complement, adventureAddressViewModel.Complement);
            Assert.Equal(adventure.Address.Postcode, adventureAddressViewModel.Postcode);
            Assert.Equal(adventure.InsurenceMinimalAmount, adventureAddressViewModel.InsurenceMinimalAmount);
            Assert.Equal(adventure.ProviderId, adventureAddressViewModel.ProviderId);
            Assert.Equal(adventure.Active, adventureAddressViewModel.Active);
        }

        [Fact(DisplayName = "Get All Adventures (with Address) by User Id")]
        [Trait(nameof(Adventure), "App Service")]
        public void Adventure_GetAllByUser_Sucess()
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

            var adventures = new Faker<Adventure>()
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
                    true
                    )).Generate(5000);

            mocker.Create<AdventureAppService>();
            var adventureAppService = mocker.Resolve<AdventureAppService>();
            var adventureService = mocker.GetMock<IAdventureService>();
            adventureService
                .Setup(a => a.GetAllWithAddressById(It.IsAny<Guid>()))
                .Returns(adventures);
            var userId = Guid.NewGuid();

            // Act
            var adventureAddressViewModels = adventureAppService.GetAllByUser(userId).ToList();

            // Assert
            adventureService.Verify(a => a.GetAllWithAddressById(It.IsAny<Guid>()), Times.Once());
            for (int i = 0; i < adventures.Count; i++)
            {
                Assert.Equal(adventures[i].AdventureId, adventureAddressViewModels[i].AdventureId);
                Assert.Equal(adventures[i].Name, adventureAddressViewModels[i].Name);
                Assert.Equal(adventures[i].CategoryId, adventureAddressViewModels[i].CategoryId);
                Assert.Equal(adventures[i].CityId, adventureAddressViewModels[i].CityId);
                Assert.Equal(adventures[i].AddressId, adventureAddressViewModels[i].AddressId);
                Assert.Equal(adventures[i].Address.Street01, adventureAddressViewModels[i].Street01);
                Assert.Equal(adventures[i].Address.Complement, adventureAddressViewModels[i].Complement);
                Assert.Equal(adventures[i].Address.Postcode, adventureAddressViewModels[i].Postcode);
                Assert.Equal(adventures[i].InsurenceMinimalAmount,
                    adventureAddressViewModels[i].InsurenceMinimalAmount);
                Assert.Equal(adventures[i].ProviderId, adventureAddressViewModels[i].ProviderId);
                Assert.Equal(adventures[i].Active, adventureAddressViewModels[i].Active);
            }
        }
    }
}
