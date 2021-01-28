using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityBuildings.Models
{
    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "اكتب اسم المستخدم")]
        [Display(Name = "User Name")]
        [EmailAddress(ErrorMessage = "اكتب اسم المستخدم في صيغة Email")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "اكتب كلمة المرور")]
        [DataType(DataType.Password, ErrorMessage = "اكتب كلمة المرور بطريقة صحيحة")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "اكتب كلمة المرور")]
        [EmailAddress(ErrorMessage = "اكتب كلمة المرور بطريقة صحيحة")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
