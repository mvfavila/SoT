using System;
using System.Linq;
using Xunit;

namespace SoT.Domain.Tests.Entities.Example
{
    public class ExampleTest
    {
        private Domain.Entities.Example.Example example;

        [Fact]
        public void MustNotAcceptExampleWithoutSubExample()
        {
            example = new Domain.Entities.Example.Example
            {
                Name = "John Doe",
                DatePropertyName = DateTime.Now
            };

            Assert.False(example.IsValid());
            Assert.Contains("Example must have a SubExample", example.ValidationResult.Errors
                .Select(error => error.Message).ToList());
        }
    }
}
