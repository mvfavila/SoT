using System;
using System.ComponentModel.DataAnnotations;

namespace SoT.Application.ViewModels
{
    public class AdventureAddressViewModel
    {
        const string DECIMAL_REGULAR_EXPRESSION = @"^\d+\.\d{0,2}$";

        public AdventureAddressViewModel()
        {
            AdventureId = Guid.NewGuid();
            CategoryId = Guid.NewGuid();
            CityId = Guid.NewGuid();
            ProviderId = Guid.NewGuid();
            AddressId = Guid.NewGuid();
        }

        // Adventure
        [ScaffoldColumn(false)]
        public Guid AdventureId { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Field Name is required")]
        [MaxLength(250, ErrorMessage = "The maximum length of the field Name is 250")]
        public string Name { get; set; }

        [ScaffoldColumn(false)]
        public Guid CategoryId { get; set; }

        [ScaffoldColumn(false)]
        public Guid CityId { get; set; }

        [Display(Name = "City")]
        [MaxLength(100, ErrorMessage = "The maximum length of the field Name is 100")]
        public string CityName { get; private set; }

        [Display(Name = "Insurence Minimal Amount")]
        [RegularExpression(DECIMAL_REGULAR_EXPRESSION)]
        [Range(0, 9999999.99)]
        public decimal? InsurenceMinimalAmount { get; set; }

        [ScaffoldColumn(false)]
        public Guid ProviderId { get; set; }
        
        public bool Active { get; set; }

        // Address
        [ScaffoldColumn(false)]
        public Guid AddressId { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Field Address is required")]
        [MaxLength(300, ErrorMessage = "The maximum length of the field Address is 300")]
        public string Street01 { get; set; }

        [MaxLength(300, ErrorMessage = "The maximum length of the field Complement is 300")]
        public string Complement { get; set; }

        [MaxLength(30, ErrorMessage = "The maximum length of the field Postcode is 30")]
        public string Postcode { get; set; }
    }
}
