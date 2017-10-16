using SoT.Domain.Interfaces.Validation;
using System;
using System.Collections.Generic;
using SoT.Domain.ValueObjects;
using SoT.Domain.Validation.Example;

namespace SoT.Domain.Entities.Example
{
    public class Example : ISelfValidator
    {
        public Example()
        {
            ExampleId = Guid.NewGuid();
            SubExamples = new List<SubExample>();
        }

        public Guid ExampleId { get; set; }

        public string Name { get; set; }

        public DateTime DatePropertyName { get; set; }


        public bool Active { get; set; }

        public DateTime RegisterDate { get; set; }

        public virtual IEnumerable<SubExample> SubExamples { get; set; }

        public ValidationResult ValidationResult { get; private set; }

        public bool IsValid()
        {
            var validation = new ExampleIsVerifiedForRegistration();
            ValidationResult = validation.Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
