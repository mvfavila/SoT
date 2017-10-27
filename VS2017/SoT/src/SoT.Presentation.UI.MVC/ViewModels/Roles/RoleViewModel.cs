using System.ComponentModel.DataAnnotations;

namespace SoT.Presentation.UI.MVC.ViewModels.Roles
{
    public class RoleViewModel
    {
        public string Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Role name")]
        public string Name { get; set; }
    }
}