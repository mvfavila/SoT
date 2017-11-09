using SoT.Domain.Entities.Example;
using System.Collections.Generic;

namespace SoT.Domain.Interfaces.Repository.ReadOnly
{
    public interface IExampleReadOnlyRepository : IBaseReadOnlyRepository<Example>
    {
        IEnumerable<Example> GetActive();
    }
}
