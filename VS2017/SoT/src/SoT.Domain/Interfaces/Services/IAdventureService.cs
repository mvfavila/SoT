using System;
using System.Collections.Generic;
using SoT.Domain.Entities;

namespace SoT.Domain.Interfaces.Services
{
    public interface IAdventureService : IBaseService<Adventure>
    {
        Adventure GetWithAddressById(Guid adventureId, Guid userId);

        IEnumerable<Adventure> GetAllWithAddressById(Guid userId);
    }
}
