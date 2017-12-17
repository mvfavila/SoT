using SoT.Domain.Entities;
using System.Collections.Generic;

namespace SoT.Domain.Interfaces.Repository.ReadOnly
{
    public interface IGenderReadOnlyRepository : IBaseReadOnlyRepository<Gender>
    {
        IEnumerable<Gender> GetAllBySituation(bool situation);
    }
}
