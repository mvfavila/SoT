using System;
using System.Collections.Generic;

namespace SoT.Domain.Entities.Example
{
    public class Example
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
    }
}
