using System;
using System.ComponentModel.DataAnnotations;

namespace SoT.Application.ViewModels
{
    public class ProviderEmployeesViewModel
    {
        public ProviderEmployeesViewModel()
        {

        }

        [ScaffoldColumn(false)]
        public Guid ProviderId { get; set; }

        [Display(Name = "Company name")]
        [Required(ErrorMessage = "Field Company name is required")]
        [MaxLength(400, ErrorMessage = "The maximum length of the field Company name is 400")]
        public string CompanyName { get; set; }

        //public virtual IEnumerable<Adventure> Adventures { get; set; }

        //public virtual IEnumerable<Employee> Employees { get; set; }

        public bool Active { get; set; }

        [Display(Name = "Register date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        [DataType(DataType.Date, ErrorMessage = "Date format invalid")]
        public DateTime RegisterDate { get; set; }
    }
}
