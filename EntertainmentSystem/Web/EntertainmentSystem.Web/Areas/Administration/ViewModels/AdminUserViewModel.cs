namespace EntertainmentSystem.Web.Areas.Administration.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;
    using Data.Models;
    using Infrastructure.Mapping;
    using Web.ViewModels;

    public class AdminUserViewModel : BaseViewModel<string>, IMapFrom<ApplicationUser>
    {
        [Display(Name = "First name")]
        [Required]
        [MaxLength(GlobalConstants.UserFirstNameMaxLength)]
        [MinLength(GlobalConstants.UserFirstNameMinLength)]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [Required]
        [MaxLength(GlobalConstants.UserLastNameMaxLength)]
        [MinLength(GlobalConstants.UserLastNameMinLength)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(GlobalConstants.UserUserNameTrueMaxLength)]
        [MinLength(GlobalConstants.UserUserNameTrueMinLength)]
        [Display(Name = "User name")]
        public string UserNameTrue { get; set; }

        [Display(Name = "Avatar")]
        [MaxLength(GlobalConstants.UserAvatarImageUrlMaxLength)]
        public string AvatarImageUrl { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(GlobalConstants.UserEmailMaxLength)]
        public string Email { get; set; }
    }
}
