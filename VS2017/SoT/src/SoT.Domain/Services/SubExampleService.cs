using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SoT.Domain.Entities.Example;
using SoT.Domain.Interfaces.Services;
using SoT.Domain.Interfaces.Repository;
using SoT.Domain.Interfaces.Repository.ReadOnly;
using SoT.Domain.ValueObjects;

namespace SoT.Domain.Services
{
    public class SubExampleService : BaseService<SubExample>, ISubExampleService
    {
        private readonly ISubExampleRepository subExampleRepository;
        private readonly ISubExampleReadOnlyRepository subExampleReadOnlyRepository;

        public SubExampleService(ISubExampleRepository subExampleRepository,
            ISubExampleReadOnlyRepository subExampleReadOnlyRepository)
            : base(subExampleRepository, subExampleReadOnlyRepository)
        {
            this.subExampleRepository = subExampleRepository;
            this.subExampleReadOnlyRepository = subExampleReadOnlyRepository;
        }

        public IEnumerable<SubExample> Find(Expression<Func<SubExample, bool>> predicate)
        {
            return subExampleReadOnlyRepository.Find(predicate);
        }

        public new IEnumerable<SubExample> GetAll()
        {
            return subExampleReadOnlyRepository.GetAll();
        }

        public new SubExample GetById(Guid id)
        {
            return subExampleReadOnlyRepository.GetById(id);
        }

        public new ValidationResult Add(SubExample subExample)
        {
            throw new NotImplementedException();
        }

        public new ValidationResult Update(SubExample subExample)
        {
            throw new NotImplementedException();
        }
    }
}
