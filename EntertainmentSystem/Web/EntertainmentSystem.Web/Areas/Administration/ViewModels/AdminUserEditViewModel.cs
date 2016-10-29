namespace EntertainmentSystem.Web.Areas.Administration.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Common.Constants;
    using Data.Models;
    using Infrastructure.Mapping;

    public class AdminUserEditViewModel : IMapFrom<ApplicationUser>, IMapTo<ApplicationUser>
    {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }

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

        [Display(Name = "Avatar")]
        [MaxLength(GlobalConstants.UserAvatarImageUrlMaxLength)]
        public string AvatarImageUrl { get; set; }

        public bool IsDeleted { get; set; }
    }
}
