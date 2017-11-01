using System;

namespace SoT.Domain.Interfaces.Repository
{
    public interface IUserRepository : IDisposable
    {
        void Unlock(string id);
    }
}
