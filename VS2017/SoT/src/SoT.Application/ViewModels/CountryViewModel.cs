using System;
using System.ComponentModel.DataAnnotations;

namespace SoT.Application.ViewModels
{
    public class CountryViewModel
    {
        public CountryViewModel()
        {
            CountryId = Guid.NewGuid();
        }

        [ScaffoldColumn(false)]
        public Guid CountryId { get; set; }

        [Required(ErrorMessage = "Field Name is required")]
        [MaxLength(70, ErrorMessage = "The maximum length of the field Name is 70")]
        public string Name { get; set; }

        [ScaffoldColumn(false)]
        public bool Active { get; set; }

        // TODO: commented only so an example implementation could be created for a Wep API class
        //public Guid RegionId { get; set; }

        //public virtual Region Region { get; set; }

        //public virtual IEnumerable<City> Cities { get; set; }
    }
}
