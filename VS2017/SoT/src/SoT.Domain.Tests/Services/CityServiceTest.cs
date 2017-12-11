using AutoMoq;
using Moq;
using SoT.Domain.Interfaces.Repository.ReadOnly;
using SoT.Domain.Services;
using System;
using Xunit;

namespace SoT.Domain.Tests.Services
{
    public class CityServiceTest
    {
        private readonly AutoMoqer mocker;

        public CityServiceTest()
        {
            mocker = new AutoMoqer();
        }

        [Fact(DisplayName = "Get Active Cities by Country Id")]
        [Trait("City", "Domain Service")]
        public void City_GetActiveByCountry_Sucess()
        {
            // Arrange
            mocker.Create<CityService>();

            var cityService = mocker.Resolve<CityService>();
            var cityRepository = mocker.GetMock<ICityReadOnlyRepository>();
            var countryId = Guid.NewGuid();

            // Act
            cityService.GetActiveByCountry(countryId);

            // Assert
            cityRepository.Verify(a => a.GetActiveByCountry(It.IsAny<Guid>()), Times.Once());
        }
    }
}
