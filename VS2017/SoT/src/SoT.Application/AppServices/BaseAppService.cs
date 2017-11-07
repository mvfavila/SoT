using SoT.Application.Interfaces;
using SoT.Application.Validation;
using SoT.Domain.ValueObjects;
using SoT.Infra.Data.Interfaces;

namespace SoT.Application.AppServices
{
    public class BaseAppService<TContext> : IBaseAppService<TContext> where TContext : IDbContext, new()
    {
        private IUnitOfWork unitOfWork;

        public void BeginTransaction()
        {
            // TODO: unitOfWork must be innitialized here
            unitOfWork.BeginTransaction();
        }

        public void Commit()
        {
            unitOfWork.SaveChanges();
        }

        protected ValidationAppResult FromDomainToApplicationResult(ValidationResult result)
        {
            var validationAppResult = new ValidationAppResult();

            foreach (var validationError in result.Errors)
            {
                validationAppResult.Errors.Add(new ValidationAppError(validationError.Message));
            }
            validationAppResult.IsValid = result.IsValid;

            return validationAppResult;
        }
    }
}
