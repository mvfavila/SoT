using System;

namespace SoT.Domain.Entities.Example
{
    public class SubExample
    {
        public SubExample()
        {
            SubExampleId = Guid.NewGuid();
        }

        public Guid SubExampleId { get; set; }

        public string StringPropertyName { get; set; }

        public DateTime DatePropertyName { get; set; }


        public bool Active { get; set; }

        public DateTime RegisterDate { get; set; }

        public virtual Guid ExampleId { get; set; }
    }
}
