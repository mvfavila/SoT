using SoT.Application.Interfaces;
using SoT.Application.Validation;
using SoT.Domain.ValueObjects;
using SoT.Infra.Data.Context;
using SoT.Infra.Data.Interfaces;
using SoT.Infra.Data.UoW;

namespace SoT.Application.AppServices
{
    public class BaseAppService<TContext> : IBaseAppService<TContext> where TContext : IDbContext, new()
    {
        private readonly IUnitOfWork<TContext> unitOfWork = new UnitOfWork<TContext>(new ContextManager());

        //public BaseAppService(IUnitOfWork<TContext> unitOfWork)
        //{
        //    this.unitOfWork = unitOfWork;
        //}

        public void BeginTransaction()
        {
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
