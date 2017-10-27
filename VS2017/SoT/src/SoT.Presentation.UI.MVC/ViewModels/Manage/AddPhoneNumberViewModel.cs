using System.ComponentModel.DataAnnotations;

namespace SoT.Presentation.UI.MVC.ViewModels.Manage
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone number")]
        public string Number { get; set; }
    }
}