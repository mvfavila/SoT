using System;
using SoT.Domain.Entities;

namespace SoT.Domain.Interfaces.Services
{
    public interface IAdventureService : IBaseService<Adventure>
    {
        Adventure GetWithAddressById(Guid adventureId, Guid userId);
    }
}
