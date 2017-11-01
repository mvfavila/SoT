using SoT.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SoT.Domain.Interfaces.Repository.ReadOnly
{
    public interface IUserReadOnlyRepository : IDisposable
    {
        User GetById(string id);
        IEnumerable<User> GetAll();
    }
}
