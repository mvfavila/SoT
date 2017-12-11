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
                .Setup(c => c.GetById(It.IsAny<Guid>()))
                .Returns(countryFaker.Generate());

            // Act
            countryAppService.GetById(It.IsAny<Guid>());

            // Assert
            countryService.Verify(c => c.GetById(It.IsAny<Guid>()), Times.Once());
        }
    }
}
