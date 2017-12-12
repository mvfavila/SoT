using AutoMoq;
using Bogus;
using Moq;
using SoT.Application.AppServices;
using SoT.Domain.Entities;
using SoT.Domain.Interfaces.Services;
using System;
using System.IO;
using System.Linq;
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
            var cities = new Faker<City>()
                .CustomInstantiator(c => City.FactoryTest(
                    Guid.NewGuid(),
                    c.Address.City(),
                    true,
                    Guid.NewGuid(),
                    null)).Generate(50000);

            mocker.Create<CityAppService>();
            var cityAppService = mocker.Resolve<CityAppService>();
            var cityService = mocker.GetMock<ICityService>();
            cityService
                .Setup(c => c.GetAll())
                .Returns(cities);

            // Act
            var cityViewModels = cityAppService.GetAll().ToList();

            // Assert
            cityService.Verify(c => c.GetAll(), Times.Once());
            for (int i = 0; i < cities.Count; i++)
            {
                Assert.Equal(cities[i].CityId, cityViewModels[i].CityId);
                Assert.Equal(cities[i].Name, cityViewModels[i].Name);
                Assert.Equal(cities[i].Active, cityViewModels[i].Active);
                Assert.Equal(cities[i].CountryId, cityViewModels[i].CountryId);
            }
        }

        [Fact(DisplayName = "Get active Cities by Country Id")]
        [Trait(nameof(City), "App Service")]
        public void City_GetActiveByCountry_Sucess()
        {
            // Arrange
            var cities = new Faker<City>()
                .CustomInstantiator(c => City.FactoryTest(
                    Guid.NewGuid(),
                    c.Address.City(),
                    true,
                    Guid.NewGuid(),
                    null)).Generate(5000);

            mocker.Create<CityAppService>();
            var cityAppService = mocker.Resolve<CityAppService>();
            var cityService = mocker.GetMock<ICityService>();
            cityService
                .Setup(c => c.GetActiveByCountry(It.IsAny<Guid>()))
                .Returns(cities);

            // Act
            var cityViewModels = cityAppService.GetActiveByCountry(Guid.NewGuid()).ToList();

            // Assert
            cityService.Verify(c => c.GetActiveByCountry(It.IsAny<Guid>()), Times.Once());
            for (int i = 0; i < cities.Count; i++)
            {
                Assert.Equal(cities[i].CityId, cityViewModels[i].CityId);
                Assert.Equal(cities[i].Name, cityViewModels[i].Name);
                Assert.Equal(cities[i].Active, cityViewModels[i].Active);
                Assert.Equal(cities[i].CountryId, cityViewModels[i].CountryId);
            }
        }
    }
}
