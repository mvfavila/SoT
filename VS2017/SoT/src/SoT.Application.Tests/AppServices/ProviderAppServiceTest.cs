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
    public class ProviderAppServiceTest
    {
        private readonly AutoMoqer mocker;

        public ProviderAppServiceTest()
        {
            mocker = new AutoMoqer();

            HttpContext.Current = new HttpContext(
                new HttpRequest("", "http://sumofthis.com", ""),
                new HttpResponse(new StringWriter())
                );
        }

        [Fact(DisplayName = "Get Provider by User Id")]
        [Trait(nameof(Provider), "App Service")]
        public void Provider_GetById_Sucess()
        {
            // Arrange
            var employeeFaker = new Faker<Employee>()
                .CustomInstantiator(e => Employee.FactoryTest(
                    Guid.NewGuid(),
                    e.Date.Past(90, DateTime.Now.AddYears(-18)),
                    Guid.NewGuid(),
                    null,
                    Guid.NewGuid()
                    ));

            var providerFaker = new Faker<Provider>()
                .CustomInstantiator(p => Provider.FactoryTest(
                    Guid.NewGuid(),
                    p.Company.CompanyName(),
                    new List<Adventure>(),
                    employeeFaker.Generate(500),
                    true));

            mocker.Create<ProviderAppService>();
            var providerAppService = mocker.Resolve<ProviderAppService>();
            var providerService = mocker.GetMock<IProviderService>();
            providerService
                .Setup(p => p.GetById(It.IsAny<Guid>()))
                .Returns(providerFaker.Generate());

            // Act
            providerAppService.GetByUserId(It.IsAny<Guid>());

            // Assert
            providerService.Verify(p => p.GetWithEmployeeById(It.IsAny<Guid>()), Times.Once());
        }
    }
}
