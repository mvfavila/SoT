using System;

namespace SoT.Domain.Entities.Example
{
    public class Example
    {
        public Example()
        {
            ExampleId = Guid.NewGuid();
        }

        public Guid ExampleId { get; set; }

        public string Name { get; set; }
    }
}
