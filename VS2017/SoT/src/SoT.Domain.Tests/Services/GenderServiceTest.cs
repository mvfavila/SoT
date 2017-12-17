using AutoMoq;
using Moq;
using SoT.Domain.Interfaces.Repository.ReadOnly;
using SoT.Domain.Services;
using Xunit;

namespace SoT.Domain.Tests.Services
{
    public class GenderServiceTest
    {
        private readonly AutoMoqer mocker;

        public GenderServiceTest()
        {
            mocker = new AutoMoqer();
        }

        [Fact(DisplayName = "Get All Active Genders")]
        [Trait("Gender", "Domain Service")]
        public void Gender_GetAllActive_Sucess()
        {
            // Arrange
            mocker.Create<GenderService>();

            var genderService = mocker.Resolve<GenderService>();
            var genderRepository = mocker.GetMock<IGenderReadOnlyRepository>();

            // Act
            genderService.GetAllActive();

            // Assert
            genderRepository.Verify(c => c.GetAllBySituation(It.Is<bool>(s => s)), Times.Once());
        }
    }
}
