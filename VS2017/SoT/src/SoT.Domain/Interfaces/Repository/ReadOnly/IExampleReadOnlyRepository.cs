using SoT.Domain.Entities.Example;
using System;
using System.Collections.Generic;

namespace SoT.Domain.Interfaces.Repository.ReadOnly
{
    public interface IExampleReadOnlyRepository : IDisposable
    {
        Example GetById(Guid id);

        IEnumerable<Example> GetAll();
    }
}
