using SoT.Domain.ValueObjects;

namespace SoT.Domain.Interfaces.Validation
{
    public interface ISelfValidator
    {
        ValidationResult ValidationResult { get; }
        bool IsValid(); 
    }
}