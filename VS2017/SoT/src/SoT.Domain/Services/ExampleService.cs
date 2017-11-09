using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SoT.Domain.Entities.Example;
using SoT.Domain.Interfaces.Services;
using SoT.Domain.Interfaces.Repository;
using SoT.Domain.Interfaces.Repository.ReadOnly;
using SoT.Domain.ValueObjects;
using SoT.Domain.Validation.Example;

namespace SoT.Domain.Services
{
    public class ExampleService : BaseService<Example>, IExampleService
    {
        private readonly IExampleRepository exampleRepository;
        private readonly IExampleReadOnlyRepository exampleReadOnlyRepository;

        public ExampleService(
            IExampleRepository exampleRepository,
            IExampleReadOnlyRepository exampleReadOnlyRepository)
            : base(exampleRepository, exampleReadOnlyRepository)
        {
            this.exampleRepository = exampleRepository;
            this.exampleReadOnlyRepository = exampleReadOnlyRepository;
        }

        public new ValidationResult Add(Example example)
        {
            var validationResult = new ValidationResult();

            if (!example.IsValid())
            {
                validationResult.AddError(example.ValidationResult);
                return validationResult;
            }

            var validator = new ExampleIsVerifiedForDatabaseRegistration(exampleReadOnlyRepository);
            var validationService = validator.Validate(example);
            if (!validationService.IsValid)
            {
                validationResult.AddError(example.ValidationResult);
                return validationResult;
            }

            exampleRepository.Add(example);

            return validationResult;
        }

        public IEnumerable<Example> Find(Expression<Func<Example, bool>> predicate)
        {
            return exampleReadOnlyRepository.Find(predicate);
        }

        public IEnumerable<Example> GetActive()
        {
            return exampleReadOnlyRepository.GetActive();
        }
    }
}
