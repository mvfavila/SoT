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

        public int CalculatedPropertyName
        {
            get
            {
                return 1 + 1;
            }
        }


        public bool Active { get; set; }

        public DateTime RegisterDate { get; set; }

        public Guid ExampleId { get; set; }

        public virtual Example Example { get; set; }
    }
}
