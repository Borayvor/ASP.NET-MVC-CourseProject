namespace EntertainmentSystem.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        [MaxLength(GlobalConstants.UserEmailMaxLength)]
        public string Email { get; set; }

        [Required]
        [MaxLength(GlobalConstants.UserUserNameMaxLength)]
        [MinLength(GlobalConstants.UserUserNameMinLength)]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [MaxLength(GlobalConstants.UserFirstNameMaxLength)]
        [MinLength(GlobalConstants.UserFirstNameMinLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(GlobalConstants.UserLastNameMaxLength)]
        [MinLength(GlobalConstants.UserLastNameMinLength)]
        public string LastName { get; set; }

        [Display(Name = "Image url")]
        [MaxLength(GlobalConstants.UserAvatarImageUrlMaxLength)]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = GlobalConstants.PasswordMinLength)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
