using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SoT.Domain.Entities.Example;
using SoT.Domain.Interfaces.Services;
using SoT.Domain.Interfaces.Repository;

namespace SoT.Domain.Services
{
    public class ExampleService : IExampleService
    {
        private readonly IExampleRepository exampleRepository;

        public ExampleService(IExampleRepository exampleRepository)
        {
            this.exampleRepository = exampleRepository;
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
            return exampleRepository.GetAll();
        }

        public Example GetById(Guid id)
        {
            return exampleRepository.GetById(id);
        }

        public void Update(Example example)
        {
            exampleRepository.Update(example);
        }

        public void Dispose()
        {
            exampleRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
