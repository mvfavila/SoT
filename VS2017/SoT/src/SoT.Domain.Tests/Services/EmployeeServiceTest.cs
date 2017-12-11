using AutoMoq;
using Bogus;
using Moq;
using SoT.Domain.Entities;
using SoT.Domain.Interfaces.Repository;
using SoT.Domain.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace SoT.Domain.Tests.Services
{
    public class EmployeeServiceTest
    {
        private readonly AutoMoqer mocker;

        public EmployeeServiceTest()
        {
            mocker = new AutoMoqer();
        }

        [Fact(DisplayName = "Add Employee Sucess")]
        [Trait(nameof(Employee), "Domain Service")]
        public void Employee_Add_Sucess()
        {
            // Arrange
            mocker.Create<EmployeeService>();

            var employeeService = mocker.Resolve<EmployeeService>();
            var employeeRepository = mocker.GetMock<IEmployeeRepository>();

            var providerFaker = new Faker<Provider>()
                .CustomInstantiator(p => Provider.FactoryTest(
                    Guid.NewGuid(),
                    p.Company.CompanyName(),
                    new List<Adventure>(),
                    new List<Employee>(),
                    true
                    ));

            var employeeFaker = new Faker<Employee>()
                .CustomInstantiator(e => Employee.FactoryTest(
                    Guid.NewGuid(),
                    e.Date.Past(90, DateTime.Now.AddYears(-18)),
                    Guid.NewGuid(),
                    providerFaker.Generate(),
                    Guid.NewGuid()
                    ));

            var employee = employeeFaker.Generate();

            // Act
            var validationResult = employeeService.Add(employee);

            // Assert
            employeeRepository.Verify(e => e.Add(employee), Times.Once());
            Assert.True(validationResult.IsValid);
            Assert.Empty(validationResult.Errors);
        }

        [Fact(DisplayName = "Update Employee Sucess")]
        [Trait(nameof(Employee), "Domain Service")]
        public void Employee_Update_Sucess()
        {
            // Arrange
            mocker.Create<EmployeeService>();

            var employeeService = mocker.Resolve<EmployeeService>();
            var employeeRepository = mocker.GetMock<IEmployeeRepository>();

            var providerFaker = new Faker<Provider>()
                .CustomInstantiator(p => Provider.FactoryTest(
                    Guid.NewGuid(),
                    p.Company.CompanyName(),
                    new List<Adventure>(),
                    new List<Employee>(),
                    true
                    ));

            var employeeFaker = new Faker<Employee>()
                .CustomInstantiator(e => Employee.FactoryTest(
                    Guid.NewGuid(),
                    e.Date.Past(90, DateTime.Now.AddYears(-18)),
                    Guid.NewGuid(),
                    providerFaker.Generate(),
                    Guid.NewGuid()
                    ));

            var employee = employeeFaker.Generate();

            // Act
            var validationResult = employeeService.Update(employee);

            // Assert
            employeeRepository.Verify(e => e.Update(employee), Times.Once());
            Assert.True(validationResult.IsValid);
            Assert.Empty(validationResult.Errors);
        }
    }
}
