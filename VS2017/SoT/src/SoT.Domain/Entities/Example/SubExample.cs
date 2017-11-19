using SoT.Domain.Interfaces.Validation;
using System;
using SoT.Domain.ValueObjects;
using SoT.Domain.Validation.SubExample;

namespace SoT.Domain.Entities.Example
{
    public class SubExample : ISelfValidator
    {
        public SubExample()
        {
            SubExampleId = Guid.NewGuid();
        }

        public Guid SubExampleId { get; set; }

        public string StringPropertyName { get; set; }

        public DateTime SubExampleDatePropertyName { get; set; }

        public int CalculatedPropertyName
        {
            get
            {
                return 1 + 1;
            }
        }

        public Guid ExampleId { get; set; }

        public virtual Example Example { get; set; }

        public ValidationResult ValidationResult { get; private set; }

        public bool IsValid()
        {
            var validation = new SubExampleIsVerifiedForRegistration();
            ValidationResult = validation.Validate(this);

            return ValidationResult.IsValid;
        }

        /// <summary>
        /// Method used internally to attach the Example to the current SubExample.
        /// </summary>
        /// <param name="example">See <see cref="Entities.Example.Example"/>.</param>
        internal void AttachProvider(Example example)
        {
            Example = example;
            ExampleId = example.ExampleId;
        }
    }
}
