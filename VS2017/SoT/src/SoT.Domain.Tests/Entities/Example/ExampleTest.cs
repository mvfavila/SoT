using System;
using NUnit.Framework;
using System.Linq;

namespace SoT.Domain.Tests.Entities.Example
{
    [TestFixture]
    public class ExampleTest
    {
        private Domain.Entities.Example.Example example;

        [Test]
        public void MustNotAcceptExampleWithoutSubExample()
        {
            example = new Domain.Entities.Example.Example
            {
                Name = "John Doe",
                DatePropertyName = DateTime.Now
            };

            Assert.IsFalse(example.IsValid());
            Assert.Contains("Example must have a SubExample", example.ValidationResult.Errors
                .Select(error => error.Message).ToList());
        }
    }
}
