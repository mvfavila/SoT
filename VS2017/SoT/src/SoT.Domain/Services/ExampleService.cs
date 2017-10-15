using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SoT.Domain.Entities.Example;
using SoT.Domain.Interfaces.Services;
using SoT.Domain.Interfaces.Repository;
using SoT.Domain.Interfaces.Repository.ReadOnly;

namespace SoT.Domain.Services
{
    public class ExampleService : IExampleService
    {
        private readonly IExampleRepository exampleRepository;
        private readonly IExampleReadOnlyRepository exampleReadOnlyRepository;

        public ExampleService(
            IExampleRepository exampleRepository,
            IExampleReadOnlyRepository exampleReadOnlyRepository)
        {
            this.exampleRepository = exampleRepository;
            this.exampleReadOnlyRepository = exampleReadOnlyRepository;
        }

        public void Add(Example example)
        {
            exampleRepository.Add(example);
        }

        public void Delete(Guid id)
        {
            exampleRepository.Delete(id);
        }

        public IEnumerable<Example> Find(Expression<Func<Example, bool>> predicate)
        {
            return exampleRepository.Find(predicate);
        }

        public IEnumerable<Example> GetActive()
        {
            return exampleRepository.GetActive();
        }

        public IEnumerable<Example> GetAll()
        {
            return exampleReadOnlyRepository.GetAll();
        }

        public Example GetById(Guid id)
        {
            return exampleReadOnlyRepository.GetById(id);
        }

        public void Update(Example example)
        {
            exampleRepository.Update(example);
        }

        public void Dispose()
        {
            exampleRepository.Dispose();
            exampleReadOnlyRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
