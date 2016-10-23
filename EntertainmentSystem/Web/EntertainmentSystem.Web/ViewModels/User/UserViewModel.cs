namespace EntertainmentSystem.Web.ViewModels.User
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;
    using Web.ViewModels;

    public class UserViewModel : BaseViewModel<string>, IMapFrom<ApplicationUser>
    {
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        public string UserName { get; set; }

        [Display(Name = "Avatar")]
        public string ImageUrl { get; set; }

        public string Email { get; set; }
    }
}
