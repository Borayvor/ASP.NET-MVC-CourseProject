namespace EntertainmentSystem.Web.Areas.Forum.ViewModels
{
    using System;
    using System.Linq;
    using AutoMapper;
    using Data.Models;
    using Data.Models.Forum;
    using Infrastructure.Mapping;
    using Web.ViewModels;

    public class CommentViewModel : BaseViewModel<Guid>, IMapFrom<Comment>, IHaveCustomMappings
    {
        public string Content { get; set; }

        public ApplicationUser Author { get; set; }

        public Guid PostId { get; set; }

        public int Votes { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(m => m.Votes, opt => opt.MapFrom(x => x.Votes.Sum(v => (int)v.Value)))
                .ReverseMap();
        }
    }
}
