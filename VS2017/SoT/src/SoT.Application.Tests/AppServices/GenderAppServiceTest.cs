using AutoMoq;
using Bogus;
using Moq;
using SoT.Application.AppServices;
using SoT.Domain.Interfaces.Services;
using System;
using System.IO;
using System.Linq;
using System.Web;
using Xunit;

namespace SoT.Application.Tests.AppServices
{
    public class GenderAppServiceTest
    {
        private readonly AutoMoqer mocker;

        public GenderAppServiceTest()
        {
            mocker = new AutoMoqer();

            HttpContext.Current = new HttpContext(
                new HttpRequest("", "http://sumofthis.com", ""),
                new HttpResponse(new StringWriter())
                );
        }

        [Fact(DisplayName = "Get all active Genders")]
        [Trait(nameof(Domain.Entities.Gender), "App Service")]
        public void Gender_GetAllActive_Sucess()
        {
            // Arrange
            var genders = new Faker<Domain.Entities.Gender>()
                .CustomInstantiator(c => Domain.Entities.Gender.FactoryTest(
                    Guid.NewGuid(),
                    c.Person.Gender.ToString(),
                    c.Random.Bool())).Generate(5000);

            mocker.Create<GenderAppService>();
            var genderAppService = mocker.Resolve<GenderAppService>();
            var genderService = mocker.GetMock<IGenderService>();
            genderService
                .Setup(c => c.GetAllActive())
                .Returns(genders);

            // Act
            var genderViewModels = genderAppService.GetAllActive().ToList();

            // Assert
            genderService.Verify(c => c.GetAllActive(), Times.Once());
            for (int i = 0; i < genders.Count; i++)
            {
                Assert.Equal(genders[i].GenderId, genderViewModels[i].GenderId);
                Assert.Equal(genders[i].Value, genderViewModels[i].Value);
                Assert.Equal(genders[i].Active, genderViewModels[i].Active);
            }
        }
    }
}
