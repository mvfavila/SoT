using SoT.Domain.Entities.Example;
using System.Collections.Generic;

namespace SoT.Domain.Interfaces.Repository
{
    public interface IExampleRepository : IBaseRepository<Example>
    {
        IEnumerable<Example> GetActive();
    }
}
