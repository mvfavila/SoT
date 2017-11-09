using SoT.Application.Interfaces;
using SoT.Application.Validation;
using SoT.Domain.ValueObjects;

namespace SoT.Application.AppServices
{
    public class BaseAppService<TEntity> : IBaseAppService<TEntity> where TEntity : class
    {
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
