using SoT.Domain.Entities;
using SoT.Domain.ValueObjects;
using System;

namespace SoT.Domain.Interfaces.Services
{
    public interface IEmployeeService : IBaseService<Employee>
    {
        new ValidationResult Add(Employee employee);

        new ValidationResult Update(Employee employee);
    }
}
