using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoT.Infra.CrossCutting.Identity
{
    [Table("AspNetClaims")]
    public class Claims
    {
        public Claims()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The Claim must have a name")]
        [MaxLength(128, ErrorMessage = "Claim Name can not exceed {0} characters")]
        [Display(Name = "Claim Name")]
        public string Name { get; set; }
    }
}
