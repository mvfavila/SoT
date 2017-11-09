using SoT.Domain.Entities.Example;
using SoT.Domain.Interfaces.Repository;
using SoT.Infra.Data.Context;

namespace SoT.Infra.Data.Repositories
{
    public class ExampleRepository : BaseRepository<Example, SoTContext>, IExampleRepository
    {
    }
}
