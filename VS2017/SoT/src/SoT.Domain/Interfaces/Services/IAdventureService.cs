using System;
using System.Collections.Generic;
using SoT.Domain.Entities;
using SoT.Domain.ValueObjects;

namespace SoT.Domain.Interfaces.Services
{
    public interface IAdventureService : IBaseService<Adventure>
    {
        new ValidationResult Add(Adventure adventure);

        Adventure GetWithAddressById(Guid adventureId, Guid userId);

        IEnumerable<Adventure> GetAllWithAddressById(Guid userId);
    }
}
