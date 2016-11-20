namespace EntertainmentSystem.Web.ViewModels.User
{
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;
    using Data.Models;
    using Infrastructure.Mapping;
    using ViewModels;

    public class UserViewModel : BaseViewModel<string>, IMapFrom<ApplicationUser>
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
        [MaxLength(GlobalConstants.UserUserNameMaxLength)]
        [MinLength(GlobalConstants.UserUserNameMinLength)]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Display(Name = "Avatar")]
        [MaxLength(GlobalConstants.UserAvatarImageUrlMaxLength)]
        public string AvatarImageUrl { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(GlobalConstants.UserEmailMaxLength)]
        public string Email { get; set; }
    }
}
