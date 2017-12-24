using SoT.Domain.Tests.Shared;
using System.Linq;
using Xunit;

namespace SoT.Domain.Tests.Validation.Employee
{
    public class EmployeeIsVerifiedForRegistrationTest
    {
        [Fact(DisplayName = "Valid instance")]
        [Trait(nameof(Employee), "Instantiation")]
        public void Employee_Instantiate_MustBeValid()
        {
            var employee = Domain.Entities.Employee.FactoryTest(
                TestConstants.EMPLOYEE_ID_VALID,
                TestConstants.EMPLOYEE_DATE_OF_BIRTH_VALID,
                TestConstants.GENDER_ID_VALID,
                TestConstants.PROVIDER_ID_VALID,
                TestConstants.PROVIDER_VALID,
                TestConstants.USER_ID_VALID
                );

            var isValid = employee.IsValid();

            Assert.True(isValid);
            Assert.False(employee.ValidationResult.Errors.Any());
        }

        [Fact(DisplayName = "Id is required")]
        [Trait(nameof(Employee), "Instantiation")]
        public void Address_Instantiate_KeyMustNotBeNull()
        {
            var employee = Domain.Entities.Employee.FactoryTest(
                TestConstants.EMPLOYEE_ID_INVALID,
                TestConstants.EMPLOYEE_DATE_OF_BIRTH_VALID,
                TestConstants.GENDER_ID_VALID,
                TestConstants.PROVIDER_ID_VALID,
                TestConstants.PROVIDER_VALID,
                TestConstants.USER_ID_VALID
                );

            var isValid = employee.IsValid();

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Employee.EmployeeId)} is required",
                employee.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact(DisplayName = "Employee must be over 18 years old")]
        [Trait(nameof(Employee), "Instantiation")]
        public void Employee_Instantiate_MustBeOver18()
        {
            var employee = Domain.Entities.Employee.FactoryTest(
                TestConstants.EMPLOYEE_ID_VALID,
                TestConstants.EMPLOYEE_DATE_OF_BIRTH_VALID_EDGE,
                TestConstants.GENDER_ID_VALID,
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
                TestConstants.GENDER_ID_VALID,
                TestConstants.PROVIDER_ID_VALID,
                TestConstants.PROVIDER_VALID,
                TestConstants.USER_ID_VALID
                );

            isValid = employee.IsValid();

            Assert.False(isValid);
            Assert.Contains($"To register as an {nameof(Domain.Entities.Employee)} must be over 18 years of age",
                employee.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact(DisplayName = "Gender Id is required")]
        [Trait(nameof(Employee), "Instantiation")]
        public void Employee_Instantiate_GenderMustNotBeNull()
        {
            var employee = Domain.Entities.Employee.FactoryTest(
                TestConstants.EMPLOYEE_ID_VALID,
                TestConstants.EMPLOYEE_DATE_OF_BIRTH_VALID,
                TestConstants.GENDER_ID_INVALID,
                TestConstants.PROVIDER_ID_VALID,
                TestConstants.PROVIDER_VALID,
                TestConstants.USER_ID_VALID
                );

            var isValid = employee.IsValid();

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Employee.Gender)} is required",
                employee.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact(DisplayName = "Provider Id is required")]
        [Trait(nameof(Employee), "Instantiation")]
        public void Employee_Instantiate_ProviderMustNotBeNull()
        {
            var employee = Domain.Entities.Employee.FactoryTest(
                TestConstants.EMPLOYEE_ID_VALID,
                TestConstants.EMPLOYEE_DATE_OF_BIRTH_VALID,
                TestConstants.GENDER_ID_VALID,
                TestConstants.PROVIDER_ID_INVALID,
                TestConstants.PROVIDER_VALID,
                TestConstants.USER_ID_VALID
                );

            var isValid = employee.IsValid();

            Assert.False(isValid);
            Assert.Contains($"{nameof(Domain.Entities.Employee.Provider)} is required",
                employee.ValidationResult.Errors.Select(error => error.Message).ToList());
        }

        [Fact(DisplayName = "User Id is required")]
        [Trait(nameof(Employee), "Instantiation")]
        public void Employee_Instantiate_UserMustNotBeNull()
        {
            var employee = Domain.Entities.Employee.FactoryTest(
                TestConstants.EMPLOYEE_ID_VALID,
                TestConstants.EMPLOYEE_DATE_OF_BIRTH_VALID,
                TestConstants.GENDER_ID_VALID,
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
