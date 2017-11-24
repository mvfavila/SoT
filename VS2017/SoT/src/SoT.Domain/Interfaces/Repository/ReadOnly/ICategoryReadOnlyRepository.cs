using System.Collections.Generic;
using SoT.Domain.Entities;

namespace SoT.Domain.Interfaces.Repository.ReadOnly
{
    public interface ICategoryReadOnlyRepository : IBaseReadOnlyRepository<Category>
    {
        IEnumerable<Category> GetAllBySituation(bool situation);
    }
}
