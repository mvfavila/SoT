using SoT.Domain.Entities;
using SoT.Domain.ValueObjects;
using System;

namespace SoT.Domain.Interfaces.Services
{
    public interface IEmployeeService : IDisposable
    {
        Employee GetById(Guid id);

        ValidationResult Add(Employee employee);

        ValidationResult Update(Employee employee);

        void Delete(Guid id);
    }
}
