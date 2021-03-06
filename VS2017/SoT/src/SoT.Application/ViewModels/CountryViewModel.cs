﻿using System;
using System.Collections.Generic;
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

        [ScaffoldColumn(false)]
        public Guid RegionId { get; set; }

        [ScaffoldColumn(false)]
        public IEnumerable<CityViewModel> Cities { get; set; }
    }
}
