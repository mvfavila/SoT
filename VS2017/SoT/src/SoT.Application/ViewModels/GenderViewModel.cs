using System;
using System.ComponentModel.DataAnnotations;

namespace SoT.Application.ViewModels
{
    public class GenderViewModel
    {
        public GenderViewModel()
        {
            GenderId = Guid.NewGuid();
        }

        [ScaffoldColumn(false)]
        public Guid GenderId { get; set; }

        [Required(ErrorMessage = "Field Value is required")]
        [MaxLength(70, ErrorMessage = "The maximum length of the field Value is 30")]
        public string Value { get; set; }

        [ScaffoldColumn(false)]
        public bool Active { get; set; }
    }
}
