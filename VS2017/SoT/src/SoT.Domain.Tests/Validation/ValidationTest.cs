using System;
using SoT.Domain.Tests.Mock;
using SoT.Domain.Entities.Example;
using SoT.Domain.Validation.Example;
using System.Linq;
using NUnit.Framework;

namespace SoT.Domain.Tests.Validation
{
    [TestFixture]
    public class ValidationTest
    {
        [Test]
        public void RegisteredExampleMustBeUniqueEntry()
        {
            var repository = new ExampleRepositoryMock();

            var example = new Example
            {
                ExampleId = Guid.Parse("6a248df2-0906-40f8-a9f2-2f3907e7165e")
            };

            var specification = new ExampleIsVerifiedForDatabaseRegistration(repository);
            Assert.Contains("Example is already registered", example.ValidationResult.Errors
                .Select(error => error.Message).ToList());
        }
    }
}
