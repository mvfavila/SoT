using SoT.Domain.Entities;
using SoT.Domain.Interfaces.Repository;
using SoT.Domain.Interfaces.Repository.ReadOnly;
using SoT.Domain.Interfaces.Services;
using SoT.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SoT.Domain.Services
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmployeeReadOnlyRepository employeeReadOnlyRepository;

        public EmployeeService(IEmployeeRepository employeeRepository,
            IEmployeeReadOnlyRepository employeeReadOnlyRepository)
            : base(employeeRepository, employeeReadOnlyRepository)
        {
            this.employeeRepository = employeeRepository;
            this.employeeReadOnlyRepository = employeeReadOnlyRepository;
        }

        ValidationResult IEmployeeService.Add(Employee employee)
        {
            throw new NotImplementedException();
        }

        ValidationResult IEmployeeService.Update(Employee employee)
        {
            throw new NotImplementedException();
        }

        new IEnumerable<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        IEnumerable<Employee> Find(Expression<Func<Employee, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        new Employee GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
