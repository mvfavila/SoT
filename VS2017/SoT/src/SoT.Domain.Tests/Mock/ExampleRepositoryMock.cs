using SoT.Domain.Entities.Example;
using SoT.Domain.Interfaces.Repository;
using System;

namespace SoT.Domain.Tests.Mock
{
    public class ExampleRepositoryMock : IExampleRepository
    {
        public void Add(Example obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Update(Example obj)
        {
            throw new NotImplementedException();
        }
    }
}
