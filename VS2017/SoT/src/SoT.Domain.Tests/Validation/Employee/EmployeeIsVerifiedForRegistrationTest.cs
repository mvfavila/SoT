using SoT.Domain.Tests.Shared;
using System.Linq;
using Xunit;

namespace SoT.Domain.Tests.Validation.Employee
{
    public class EmployeeIsVerifiedForRegistrationTest
    {
        [Fact]
        public void Employee_Instantiate_MustBeValid()
        {
            var employee = Domain.Entities.Employee.FactoryTest(
                TestConstants.EMPLOYEE_ID_VALID,
                TestConstants.EMPLOYEE_DATE_OF_BIRTH_VALID,
                TestConstants.PROVIDER_ID_VALID,
                TestConstants.PROVIDER_VALID,
                TestConstants.USER_ID_VALID
                );

            var isValid = employee.IsValid();

            Assert.True(isValid);
            Assert.False(employee.ValidationResult.Errors.Any());
        }

        [Fact]
        public void Employee_Instantiate_MustBeOver18()
        {
            var employee = Domain.Entities.Employee.FactoryTest(
                TestConstants.EMPLOYEE_ID_VALID,
                TestConstants.EMPLOYEE_DATE_OF_BIRTH_VALID_EDGE,
                TestConstants.PROVIDER_ID_VALID,
                TestConstants.PROVIDER_VALID,
                TestConstants.USER_ID_VALID
                );

            var isValid = employee.IsValid();

            Assert.True(isValid);
            Assert.False(employee.ValidationResult.Errors.Any());

            employee = Domain.Entities.Employee.FactoryTest(
                TestConstants.EMPLOYEE_ID_VALID,
                TestConstants.EMPLOYEE_DATE_OF_BIRTH_INVALID,
                TestConstants.PROVIDER_ID_VALID,
                TestConstants.PROVIDER_VALID,
                TestConstants.USER_ID_VALID
                );

            isValid = employee.IsValid();

            Assert.False(isValid);
            Assert.Contains($"To register as an {nameof(Domain.Entities.Employee)} must be over 18 years of age",
                employee.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact]
        public void Employee_Instantiate_ProviderMustNotBeNull()
        {
            var employee = Domain.Entities.Employee.FactoryTest(
                TestConstants.EMPLOYEE_ID_VALID,
                TestConstants.EMPLOYEE_DATE_OF_BIRTH_VALID,
                TestConstants.PROVIDER_ID_INVALID,
                TestConstants.PROVIDER_VALID,
                TestConstants.USER_ID_VALID
                );

            var isValid = employee.IsValid();

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Employee.Provider)} is required",
                employee.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact]
        public void Employee_Instantiate_UserMustNotBeNull()
        {
            var employee = Domain.Entities.Employee.FactoryTest(
                TestConstants.EMPLOYEE_ID_VALID,
                TestConstants.EMPLOYEE_DATE_OF_BIRTH_VALID,
                TestConstants.PROVIDER_ID_INVALID,
                TestConstants.PROVIDER_VALID,
                TestConstants.USER_ID_INVALID
                );

            var isValid = employee.IsValid();

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Employee.UserId)} is required",
                employee.ValidationResult.Errors.Select(error => error.Message).ToList());
        }
    }
}
