using AutoMoq;
using Bogus;
using Moq;
using SoT.Application.AppServices;
using SoT.Domain.Entities;
using SoT.Domain.Interfaces.Services;
using System;
using System.IO;
using System.Web;
using Xunit;

namespace SoT.Application.Tests.AppServices
{
    public class CityAppServiceTest
    {
        private readonly AutoMoqer mocker;

        public CityAppServiceTest()
        {
            mocker = new AutoMoqer();

            HttpContext.Current = new HttpContext(
                new HttpRequest("", "http://sumofthis.com", ""),
                new HttpResponse(new StringWriter())
                );
        }

        [Fact(DisplayName = "Get all Cities")]
        [Trait(nameof(City), "App Service")]
        public void City_GetAll_Sucess()
        {
            // Arrange
            var country = new Faker<Country>()
                .CustomInstantiator(c => Country.FactoryTest(
                    Guid.NewGuid(),
                    c.Address.Country(),
                    c.Random.Bool(),
                    Guid.NewGuid(),
                    null)).Generate();

            var cityFaker = new Faker<City>()
                .CustomInstantiator(c => City.FactoryTest(
                    Guid.NewGuid(),
                    c.Address.City(),
                    true,
                    country.CountryId,
                    country));

            mocker.Create<CityAppService>();
            var cityAppService = mocker.Resolve<CityAppService>();
            var cityService = mocker.GetMock<ICityService>();
            cityService
                .Setup(c => c.GetAll())
                .Returns(cityFaker.Generate(50000));

            // Act
            cityAppService.GetAll();

            // Assert
            cityService.Verify(c => c.GetAll(), Times.Once());
        }

        [Fact(DisplayName = "Get active Cities by Country Id")]
        [Trait(nameof(City), "App Service")]
        public void City_GetActiveByCountry_Sucess()
        {
            // Arrange
            var country = new Faker<Country>()
                .CustomInstantiator(c => Country.FactoryTest(
                    Guid.NewGuid(),
                    c.Address.Country(),
                    c.Random.Bool(),
                    Guid.NewGuid(),
                    null)).Generate();

            var cityFaker = new Faker<City>()
                .CustomInstantiator(c => City.FactoryTest(
                    Guid.NewGuid(),
                    c.Address.City(),
                    true,
                    country.CountryId,
                    country));

            mocker.Create<CityAppService>();
            var cityAppService = mocker.Resolve<CityAppService>();
            var cityService = mocker.GetMock<ICityService>();
            cityService
                .Setup(c => c.GetActiveByCountry(It.IsAny<Guid>()))
                .Returns(cityFaker.Generate(5000));

            // Act
            cityAppService.GetActiveByCountry(Guid.NewGuid());

            // Assert
            cityService.Verify(c => c.GetActiveByCountry(It.IsAny<Guid>()), Times.Once());
        }
    }
}
