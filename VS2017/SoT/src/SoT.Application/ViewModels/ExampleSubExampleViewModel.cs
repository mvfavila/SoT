using System;

namespace SoT.Application.ViewModels
{
    public class ExampleSubExampleViewModel
    {
        public ExampleSubExampleViewModel()
        {
            ExampleId = Guid.NewGuid();
            SubExampleId = Guid.NewGuid();
        }

        // Example
        public Guid ExampleId { get; set; }

        public string Name { get; set; }

        public DateTime DatePropertyName { get; set; }

        public DateTime RegisterDate { get; set; }

        // SubExample

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
    }
}
