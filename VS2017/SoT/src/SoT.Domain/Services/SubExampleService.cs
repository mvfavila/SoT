using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SoT.Domain.Entities.Example;
using SoT.Domain.Interfaces.Services;
using SoT.Domain.Interfaces.Repository;

namespace SoT.Domain.Services
{
    public class SubExampleService : ISubExampleService
    {
        private readonly ISubExampleRepository subExampleRepository;

        public SubExampleService(ISubExampleRepository subExampleRepository)
        {
            this.subExampleRepository = subExampleRepository;
        }

        public void Add(SubExample subExample)
        {
            subExampleRepository.Add(subExample);
        }

        public void Delete(Guid id)
        {
            subExampleRepository.Delete(id);
        }

        public void Dispose()
        {
            subExampleRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<SubExample> Find(Expression<Func<SubExample, bool>> predicate)
        {
            return subExampleRepository.Find(predicate);
        }

        public IEnumerable<SubExample> GetAll()
        {
            return subExampleRepository.GetAll();
        }

        public SubExample GetById(Guid id)
        {
            return subExampleRepository.GetById(id);
        }

        public void Update(SubExample subExample)
        {
            subExampleRepository.Update(subExample);
        }
    }
}
