using SoT.Domain.Entities;
using SoT.Domain.Interfaces.Repository;
using SoT.Infra.Data.Context;

namespace SoT.Infra.Data.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee, SoTContext>, IEmployeeRepository
    {
    }
}
