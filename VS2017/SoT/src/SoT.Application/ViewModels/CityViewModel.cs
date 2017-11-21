using System;
using System.ComponentModel.DataAnnotations;

namespace SoT.Application.ViewModels
{
    public class CityViewModel
    {
        public CityViewModel()
        {
            CityId = Guid.NewGuid();
            CountryId = Guid.NewGuid();
        }

        [ScaffoldColumn(false)]
        public Guid CityId { get; set; }

        [Required(ErrorMessage = "Field Name is required")]
        [MaxLength(100, ErrorMessage = "The maximum length of the field Name is 100")]
        public string Name { get; set; }

        [ScaffoldColumn(false)]
        public bool Active { get; set; }

        [ScaffoldColumn(false)]
        public Guid CountryId { get; set; }
    }
}
