using SoT.Domain.Entities.Example;
using SoT.Domain.Interfaces.Repository;
using SoT.Infra.Data.Context;
using System.Collections.Generic;

namespace SoT.Infra.Data.Repositories
{
    public class ExampleRepository : BaseRepository<Example, SoTContext>, IExampleRepository
    {
        public IEnumerable<Example> GetActive()
        {
            return Find(e => e.Active);
        }
    }
}
