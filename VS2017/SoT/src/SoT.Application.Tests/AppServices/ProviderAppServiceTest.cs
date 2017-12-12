using AutoMoq;
using Bogus;
using Moq;
using SoT.Application.AppServices;
using SoT.Application.ViewModels;
using SoT.Domain.Entities;
using SoT.Domain.Interfaces.Repository;
using SoT.Domain.Interfaces.Repository.ReadOnly;
using SoT.Domain.Interfaces.Services;
using SoT.Domain.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        [Fact(DisplayName = "Add Provider")]
        [Trait(nameof(Provider), "App Service")]
        public void Provider_Add_Sucess()
        {
            // Arrange
            var employeeProviderViewModelFaker = new Faker<EmployeeProviderViewModel>()
                .CustomInstantiator(p => new EmployeeProviderViewModel
                {
                    EmployeeId = Guid.NewGuid(),
                    CompanyName = p.Company.CompanyName(),
                    BirthDate = p.Date.Past(90, DateTime.Now.AddYears(-18)),
                    ProviderId = Guid.NewGuid(),
                    UserId = Guid.NewGuid(),
                    Active = true
                });

            var employeeRepository = new Mock<IEmployeeRepository>().Object;
            var employeeReadOnlyRepository = new Mock<IEmployeeReadOnlyRepository>().Object;
            var providerRepository = new Mock<IProviderRepository>().Object;
            var providerReadOnlyRepository = new Mock<IProviderReadOnlyRepository>().Object;

            var employeeService = new Mock<EmployeeService>(employeeRepository, employeeReadOnlyRepository);
            var providerService = new Mock<ProviderService>(providerRepository, providerReadOnlyRepository);

            var providerAppService = new Mock<ProviderAppService>(employeeService.Object, providerService.Object);
            providerAppService
                .Setup(p => p.Commit());

            var result = new Domain.ValueObjects.ValidationResult();

            employeeService
                .Setup(e => e.Add(It.IsAny<Employee>()))
                .Returns(result);
            var employeeProviderViewModel = employeeProviderViewModelFaker.Generate();

            // Act
            providerAppService.Object.Add(employeeProviderViewModel);

            // Assert
            employeeService.Verify(p => p.Add(It.IsAny<Employee>()), Times.Once());
        }

        [Fact(DisplayName = "Get Provider by User Id")]
        [Trait(nameof(Provider), "App Service")]
        public void Provider_GetById_Sucess()
        {
            // Arrange
            var providerId = Guid.NewGuid();
            var employees = new Faker<Employee>()
                .CustomInstantiator(e => Employee.FactoryTest(
                    Guid.NewGuid(),
                    e.Date.Past(90, DateTime.Now.AddYears(-18)),
                    providerId,
                    null,
                    Guid.NewGuid()
                    )).Generate(500);

            var provider = new Faker<Provider>()
                .CustomInstantiator(p => Provider.FactoryTest(
                    providerId,
                    p.Company.CompanyName(),
                    new List<Adventure>(),
                    employees,
                    true)).Generate();

            mocker.Create<ProviderAppService>();
            var providerAppService = mocker.Resolve<ProviderAppService>();
            var providerService = mocker.GetMock<IProviderService>();
            providerService
                .Setup(p => p.GetWithEmployeeById(It.IsAny<Guid>()))
                .Returns(provider);

            // Act
            var employeeProviderViewModel = providerAppService.GetByUserId(It.IsAny<Guid>());

            // Assert
            providerService.Verify(p => p.GetWithEmployeeById(It.IsAny<Guid>()), Times.Once());
            Assert.Equal(provider.ProviderId, employeeProviderViewModel.ProviderId);
            Assert.Equal(provider.CompanyName, employeeProviderViewModel.CompanyName);
            var firstEmployee = provider.Employees.FirstOrDefault();
            Assert.Equal(firstEmployee.EmployeeId, employeeProviderViewModel.EmployeeId);
            Assert.Equal(firstEmployee.BirthDate, employeeProviderViewModel.BirthDate);
            Assert.Equal(firstEmployee.ProviderId, employeeProviderViewModel.ProviderId);
            Assert.Equal(firstEmployee.UserId, employeeProviderViewModel.UserId);
        }

        [Fact(DisplayName = "Update Provider")]
        [Trait(nameof(Provider), "App Service")]
        public void Provider_Update_Sucess()
        {
            // Arrange
            var employeeProviderViewModelFaker = new Faker<EmployeeProviderViewModel>()
                .CustomInstantiator(p => new EmployeeProviderViewModel
                {
                    EmployeeId = Guid.NewGuid(),
                    CompanyName = p.Company.CompanyName(),
                    BirthDate = p.Date.Past(90, DateTime.Now.AddYears(-18)),
                    ProviderId = Guid.NewGuid(),
                    UserId = Guid.NewGuid(),
                    Active = true
                });

            var employeeRepository = new Mock<IEmployeeRepository>().Object;
            var employeeReadOnlyRepository = new Mock<IEmployeeReadOnlyRepository>().Object;
            var providerRepository = new Mock<IProviderRepository>().Object;
            var providerReadOnlyRepository = new Mock<IProviderReadOnlyRepository>().Object;

            var employeeService = new Mock<EmployeeService>(employeeRepository, employeeReadOnlyRepository);
            var providerService = new Mock<ProviderService>(providerRepository, providerReadOnlyRepository);

            var providerAppService = new Mock<ProviderAppService>(employeeService.Object, providerService.Object);
            providerAppService
                .Setup(p => p.Commit());

            var result = new Domain.ValueObjects.ValidationResult();

            employeeService
                .Setup(e => e.Update(It.IsAny<Employee>()))
                .Returns(result);
            var employeeProviderViewModel = employeeProviderViewModelFaker.Generate();

            // Act
            providerAppService.Object.Update(employeeProviderViewModel);

            // Assert
            employeeService.Verify(p => p.Update(It.IsAny<Employee>()), Times.Once());
        }
    }
}
