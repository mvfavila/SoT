using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoT.Application.ViewModels
{
    public class EmployeeProviderViewModel
    {
        public EmployeeProviderViewModel()
        {
            EmployeeId = Guid.NewGuid();
            ProviderId = Guid.NewGuid();
        }

        // Employee

        [ScaffoldColumn(false)]
        public Guid EmployeeId { get; set; }

        [Display(Name = "Birth date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Date format invalid")]
        public DateTime BirthDate { get; set; }

        [ScaffoldColumn(false)]
        public Guid GenderId { get; set; }

        public IEnumerable<GenderViewModel> Genders { get; set; }

        [ScaffoldColumn(false)]
        public Guid UserId { get; set; }

        // Provider

        [ScaffoldColumn(false)]
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
