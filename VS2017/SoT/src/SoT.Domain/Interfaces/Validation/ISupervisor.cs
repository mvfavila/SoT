using SoT.Domain.ValueObjects;

namespace SoT.Domain.Interfaces.Validation
{
    public interface ISupervisor<in TEntity>
    {
        ValidationResult Validate(TEntity entity);
    }
}
