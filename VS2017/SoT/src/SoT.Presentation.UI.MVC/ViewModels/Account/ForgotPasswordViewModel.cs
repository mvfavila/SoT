﻿using System.ComponentModel.DataAnnotations;

namespace SoT.Presentation.UI.MVC.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}