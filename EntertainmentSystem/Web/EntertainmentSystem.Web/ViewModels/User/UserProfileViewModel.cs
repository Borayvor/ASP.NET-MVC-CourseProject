namespace EntertainmentSystem.Web.ViewModels.User
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class UserProfileViewModel : BaseViewModel<string>,
        IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Display(Name = "Avatar")]
        public string AvatarImageUrl { get; set; }

        public string Email { get; set; }

        public int Posts { get; set; }

        public int Comments { get; set; }

        public int Votes { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<ApplicationUser, UserProfileViewModel>()
                .ForMember(m => m.Posts, opt => opt.MapFrom(x => x.Posts.Count()))
                .ForMember(m => m.Comments, opt => opt.MapFrom(x => x.Comments.Count()))
                .ForMember(m => m.Votes, opt => opt.MapFrom(x => x.Votes.Sum(v => (int)v.Value)))
                .ReverseMap();
        }
    }
}
