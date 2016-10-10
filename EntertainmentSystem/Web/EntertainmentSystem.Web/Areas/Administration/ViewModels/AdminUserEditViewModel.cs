namespace EntertainmentSystem.Web.Areas.Administration.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;

    public class AdminUserEditViewModel : IMapFrom<ApplicationUser>, IMapTo<ApplicationUser>
    {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }

        [Display(Name = "First name")]
        [Required]
        [MaxLength(100)]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [Required]
        [MaxLength(100)]
        [MinLength(2)]
        public string LastName { get; set; }

        [Display(Name = "Avatar")]
        [MaxLength(1024)]
        public string ImageUrl { get; set; }
    }
}
