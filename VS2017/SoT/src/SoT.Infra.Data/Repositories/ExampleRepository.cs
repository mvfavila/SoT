using System.Collections.Generic;
using SoT.Domain.Entities.Example;
using SoT.Domain.Interfaces.Repository;

namespace SoT.Infra.Data.Repositories
{
    public class ExampleRepository : BaseRepository<Example>, IExampleRepository
    {
        public IEnumerable<Example> GetActive()
        {
            return Find(e => e.Active);
        }
    }
}
