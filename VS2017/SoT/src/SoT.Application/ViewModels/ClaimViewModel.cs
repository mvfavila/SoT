using System;
using System.ComponentModel.DataAnnotations;

namespace SoT.Application.ViewModels
{
    public class ClaimViewModel
    {
        public ClaimViewModel()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Claim must have a name")]
        [MaxLength(128, ErrorMessage = "Claim length can not exceed {0} characteres")]
        [Display(Name = "Claim name")]
        public string Name { get; set; }
    }
}
