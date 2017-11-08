using System;
using System.ComponentModel.DataAnnotations;

namespace SoT.Application.ViewModels
{
    public class EmployeeProviderViewModel
    {
        public EmployeeProviderViewModel()
        {
            Id = Guid.NewGuid().ToString();
            ProviderId = Guid.NewGuid();
        }

        // User

        public string Id { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Field E-mail is required")]
        [MaxLength(200, ErrorMessage = "The maximum length of the field Name is 200")]
        public string Email { get; set; }

        // Employee

        [Required(ErrorMessage = "Field Name is required")]
        [MaxLength(200, ErrorMessage = "The maximum length of the field Name is 200")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field Surname is required")]
        [MaxLength(200, ErrorMessage = "The maximum length of the field Surname is 200")]
        public string Surname { get; set; }

        [Display(Name = "Birth date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Date format invalid")]
        public DateTime BirthDate { get; set; }

        // Provider
        public Guid ProviderId { get; set; }

        [Display(Name = "Company name")]
        [Required(ErrorMessage = "Field Company name is required")]
        [MaxLength(400, ErrorMessage = "The maximum length of the field Company name is 400")]
        public string CompanyName { get; set; }

        [ScaffoldColumn(false)]
        public bool Active { get; set; }

        [ScaffoldColumn(false)]
        public DateTime RegisterDate { get; set; }
    }
}
