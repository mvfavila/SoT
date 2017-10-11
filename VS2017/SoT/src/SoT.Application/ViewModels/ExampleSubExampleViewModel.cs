using System;
using System.ComponentModel.DataAnnotations;

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

        // SubExample

        public Guid SubExampleId { get; set; }

        [Required(ErrorMessage = "Field E-mail is required")]
        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "E-mail format invalid")]
        public string StringPropertyName { get; set; }

        [Display(Name = "Example Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Date format invalid")]
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
