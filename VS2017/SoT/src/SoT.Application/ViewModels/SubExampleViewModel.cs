using System;
using System.ComponentModel.DataAnnotations;

namespace SoT.Application.ViewModels
{
    public class SubExampleViewModel
    {
        public SubExampleViewModel()
        {
            SubExampleId = Guid.NewGuid();
        }

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

        [ScaffoldColumn(false)]
        public Guid ExampleId { get; set; }

        [ScaffoldColumn(false)]
        public virtual ExampleViewModel Example { get; set; }
    }
}
