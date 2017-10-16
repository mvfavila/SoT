using System.Collections.Generic;
using System.Linq;

namespace SoT.Domain.ValueObjects
{
    public class ValidationResult
    {
        private readonly List<ValidationError> errors = new List<ValidationError>();

        public string Message { get; set; }
        public bool IsValid { get { return errors.Count == 0; } }

        public IEnumerable<ValidationError> Errors { get { return this.errors; } }

        public void AddError(ValidationError error)
        {
            errors.Add(error);
        }

        public void AddError(params ValidationResult[] validationResults)
        {
            if (validationResults == null) return;

            foreach (var validationResult in validationResults.Where(result => result != null))
                this.errors.AddRange(validationResult.Errors);
        }

        public void RemoveError(ValidationError error)
        {
            if (errors.Contains(error))
                errors.Remove(error);
        }
    }
}
