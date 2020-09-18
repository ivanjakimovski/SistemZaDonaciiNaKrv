using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemZaDonaciiNaKrv.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Внесете е-адреса.")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Внесете лозинка.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {

        [Required(ErrorMessage = "Внесете име.")]
        [Display(Name = "Име:")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Внесете презиме.")]
        [Display(Name = "Презиме:")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Внесете адреса.")]
        [Display(Name = "Адреса:")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Внесете град.")]
        [Display(Name = "Град:")]
        public string City { get; set; }

        [Required(ErrorMessage = "Изберете пол.")]
        [Display(Name = "Пол:")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Изберете крвна група.")]
        [Display(Name = "Крвна група:")]
        public string BloodType { get; set; }

        [Required(ErrorMessage = "Внесете е-адреса.")]
        [EmailAddress]
        [Display(Name = "Е-адреса")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Внесете телефон.")]
        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Внесете лозинка.")]
        [StringLength(100, ErrorMessage = "Лозинката мора да биде долга најмалку 8 карактери.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public List<string> Genders { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Лозинката и потврдата на лозинката не се еднакви.")]
        public string ConfirmPassword { get; set; }

        public RegisterViewModel()
        {
            Genders = new List<string>();
        }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Лозинката мора да биде долга најмалку 8 карактери.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Лозинката и потврдата на лозинката не се еднакви.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
