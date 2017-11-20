using System;
using SoT.Domain.Entities;

namespace SoT.Domain.Interfaces.Repository.ReadOnly
{
    public interface IAdventureReadOnlyRepository : IBaseReadOnlyRepository<Adventure>
    {
        Adventure GetWithAddressById(Guid adventureId, Guid userId);
    }
}
