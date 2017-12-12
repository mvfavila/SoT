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
    public class CountryAppServiceTest
    {
        private readonly AutoMoqer mocker;

        public CountryAppServiceTest()
        {
            mocker = new AutoMoqer();

            HttpContext.Current = new HttpContext(
                new HttpRequest("", "http://sumofthis.com", ""),
                new HttpResponse(new StringWriter())
                );
        }

        [Fact(DisplayName = "Get Country by Id")]
        [Trait(nameof(Country), "App Service")]
        public void Country_GetById_Sucess()
        {
            // Arrange
            var country = new Faker<Country>()
                .CustomInstantiator(c => Country.FactoryTest(
                    Guid.NewGuid(),
                    c.Address.Country(),
                    c.Random.Bool(),
                    Guid.NewGuid(),
                    null)).Generate();

            mocker.Create<CountryAppService>();
            var countryAppService = mocker.Resolve<CountryAppService>();
            var countryService = mocker.GetMock<ICountryService>();
            countryService
                .Setup(c => c.GetById(It.IsAny<Guid>()))
                .Returns(country);

            // Act
            var countryViewModel = countryAppService.GetById(It.IsAny<Guid>());

            // Assert
            countryService.Verify(c => c.GetById(It.IsAny<Guid>()), Times.Once());
            Assert.Equal(country.CountryId, countryViewModel.CountryId);
            Assert.Equal(country.Name, countryViewModel.Name);
            Assert.Equal(country.Active, countryViewModel.Active);
            Assert.Equal(country.RegionId, countryViewModel.RegionId);
        }

        [Fact(DisplayName = "Get all Countries")]
        [Trait(nameof(Country), "App Service")]
        public void Country_GetAll_Sucess()
        {
            // Arrange
            var countries = new Faker<Country>()
                .CustomInstantiator(c => Country.FactoryTest(
                    Guid.NewGuid(),
                    c.Address.Country(),
                    c.Random.Bool(),
                    Guid.NewGuid(),
                    null)).Generate(50000);

            mocker.Create<CountryAppService>();
            var countryAppService = mocker.Resolve<CountryAppService>();
            var countryService = mocker.GetMock<ICountryService>();
            countryService
                .Setup(c => c.GetAll())
                .Returns(countries);

            // Act
            var countryViewModels = countryAppService.GetAll().ToList();

            // Assert
            countryService.Verify(c => c.GetAll(), Times.Once());
            for (int i = 0; i < countries.Count; i++)
            {
                Assert.Equal(countries[i].CountryId, countryViewModels[i].CountryId);
                Assert.Equal(countries[i].Name, countryViewModels[i].Name);
                Assert.Equal(countries[i].Active, countryViewModels[i].Active);
                Assert.Equal(countries[i].RegionId, countryViewModels[i].RegionId);
            }
        }

        [Fact(DisplayName = "Get all active Countries")]
        [Trait(nameof(Country), "App Service")]
        public void Country_GetAllActive_Sucess()
        {
            // Arrange
            var countryFaker = new Faker<Country>()
                .CustomInstantiator(c => Country.FactoryTest(
                    Guid.NewGuid(),
                    c.Address.Country(),
                    c.Random.Bool(),
                    Guid.NewGuid(),
                    null));

            mocker.Create<CountryAppService>();
            var countryAppService = mocker.Resolve<CountryAppService>();
            var countryService = mocker.GetMock<ICountryService>();
            countryService
                .Setup(c => c.GetAllActive())
                .Returns(countryFaker.Generate(5000));

            // Act
            countryAppService.GetAllActive();

            // Assert
            countryService.Verify(c => c.GetAllActive(), Times.Once());
        }
    }
}
