using SoT.Domain.Entities.Example;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoT.Application.ViewModels
{
    public class ExampleViewModel
    {
        public ExampleViewModel()
        {
            ExampleId = Guid.NewGuid();
            SubExamples = new List<SubExampleViewModel>();
        }

        // Example
        public Guid ExampleId { get; set; }

        [Required(ErrorMessage = "Field name is required")]
        [MaxLength(150, ErrorMessage = "The maximum length of the field Name is 150")]
        public string Name { get; set; }

        [Display(Name = "Example Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Date format invalid")]
        public DateTime DatePropertyName { get; set; }

        [ScaffoldColumn(false)]
        public bool Active { get; set; }

        [ScaffoldColumn(false)]
        public DateTime RegisterDate { get; set; }

        [ScaffoldColumn(false)]
        public IEnumerable<SubExampleViewModel> SubExamples { get; set; }
    }
}
