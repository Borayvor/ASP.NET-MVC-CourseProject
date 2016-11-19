namespace EntertainmentSystem.Web.Areas.Forum.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Data.Models;
    using Data.Models.Forum;
    using Infrastructure.Mapping;
    using Web.ViewModels;

    public class PostViewModel : BaseViewModel<Guid>, IMapFrom<Post>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public ApplicationUser Author { get; set; }

        public ForumCategory Category { get; set; }

        public IEnumerable<Tag> Tags { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        public int Votes { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Post, PostHomeViewModel>()
                .ForMember(m => m.Category, opt => opt.MapFrom(x => x.PostCategory))
                .ForMember(m => m.Votes, opt => opt.MapFrom(x => x.Votes.Sum(v => (int)v.Value)))
                .ReverseMap();
        }
    }
}
