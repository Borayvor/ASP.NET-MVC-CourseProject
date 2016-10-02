﻿namespace EntertainmentSystem.Web.Areas.Administration.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;

    public class AdminUsersViewModel : AdminBaseStringViewModel, IMapFrom<ApplicationUser>
    {
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Display(Name = "Avatar")]
        public string ImageUrl { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
    }
}
