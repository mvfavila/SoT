using NUnit.Framework;
using SoT.Domain.Tests.Shared;
using System.Linq;

namespace SoT.Domain.Tests.Validation.Employee
{
    [TestFixture]
    public class EmployeeIsVerifiedForRegistrationTest
    {
        [Test]
        public void EmployeeMustBeValid()
        {
            var employee = Domain.Entities.Employee.FactoryTest(
                TestConstants.EMPLOYEE_ID_VALID,
                TestConstants.EMPLOYEE_DATE_OF_BIRTH_VALID,
                TestConstants.PROVIDER_ID_VALID,
                TestConstants.PROVIDER_VALID,
                TestConstants.USER_ID_VALID
                );

            var isValid = employee.IsValid();

            Assert.IsTrue(isValid);
            Assert.IsFalse(employee.ValidationResult.Errors.Any());
        }

        [Test]
        public void EmployeeMustBeOver18()
        {
            var employee = Domain.Entities.Employee.FactoryTest(
                TestConstants.EMPLOYEE_ID_VALID,
                TestConstants.EMPLOYEE_DATE_OF_BIRTH_VALID_EDGE,
                TestConstants.PROVIDER_ID_VALID,
                TestConstants.PROVIDER_VALID,
                TestConstants.USER_ID_VALID
                );

            var isValid = employee.IsValid();

            Assert.IsTrue(isValid);
            Assert.IsFalse(employee.ValidationResult.Errors.Any());

            employee = Domain.Entities.Employee.FactoryTest(
                TestConstants.EMPLOYEE_ID_VALID,
                TestConstants.EMPLOYEE_DATE_OF_BIRTH_INVALID,
                TestConstants.PROVIDER_ID_VALID,
                TestConstants.PROVIDER_VALID,
                TestConstants.USER_ID_VALID
                );

            isValid = employee.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains($"To register as an {nameof(Domain.Entities.Employee)} must be over 18 years of age",
                employee.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Test]
        public void EmployeeProviderMustNotBeNull()
        {
            var employee = Domain.Entities.Employee.FactoryTest(
                TestConstants.EMPLOYEE_ID_VALID,
                TestConstants.EMPLOYEE_DATE_OF_BIRTH_VALID,
                TestConstants.PROVIDER_ID_INVALID,
                TestConstants.PROVIDER_VALID,
                TestConstants.USER_ID_VALID
                );

            var isValid = employee.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Employee.Provider)} is required",
                employee.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Test]
        public void EmployeeUserMustNotBeNull()
        {
            var employee = Domain.Entities.Employee.FactoryTest(
                TestConstants.EMPLOYEE_ID_VALID,
                TestConstants.EMPLOYEE_DATE_OF_BIRTH_VALID,
                TestConstants.PROVIDER_ID_INVALID,
                TestConstants.PROVIDER_VALID,
                TestConstants.USER_ID_INVALID
                );

            var isValid = employee.IsValid();

            Assert.IsFalse(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Employee.UserId)} is required",
                employee.ValidationResult.Errors.Select(error => error.Message).ToList());
        }
    }
}
