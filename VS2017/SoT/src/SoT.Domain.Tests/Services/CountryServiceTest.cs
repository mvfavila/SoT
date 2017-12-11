using AutoMoq;
using Moq;
using SoT.Domain.Interfaces.Repository.ReadOnly;
using SoT.Domain.Services;
using Xunit;

namespace SoT.Domain.Tests.Services
{
    public class CountryServiceTest
    {
        private readonly AutoMoqer mocker;

        public CountryServiceTest()
        {
            mocker = new AutoMoqer();
        }

        [Fact(DisplayName = "Get All Active Countries")]
        [Trait("Country", "Domain Service")]
        public void Country_GetAllActive_Sucess()
        {
            // Arrange
            mocker.Create<CountryService>();

            var countryService = mocker.Resolve<CountryService>();
            var countryRepository = mocker.GetMock<ICountryReadOnlyRepository>();

            // Act
            countryService.GetAllActive();

            // Assert
            countryRepository.Verify(c => c.GetAllBySituation(It.Is<bool>(s => s)), Times.Once());
        }
    }
}
