using SoT.Domain.Entities;
using SoT.Domain.Interfaces.Repository.ReadOnly;
using SoT.Infra.Data.Context;

namespace SoT.Infra.Data.Repositories.ReadOnly
{
    public class CountryReadOnlyRepository : BaseReadOnlyRepository<Country, SoTContext>, ICountryReadOnlyRepository
    {
        // TODO: override methods to use Dapper instead of EF
    }
}
