using System;
using SoT.Domain.Entities;
using SoT.Domain.Interfaces.Services;
using SoT.Domain.ValueObjects;

namespace SoT.Domain.Services
{
    public class EmployeeService : IEmployeeService
    {
        public ValidationResult Add(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Employee GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Update(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
