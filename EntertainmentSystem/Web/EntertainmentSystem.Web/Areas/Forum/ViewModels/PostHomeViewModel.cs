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

    public class PostHomeViewModel : BaseViewModel<Guid>, IMapFrom<Post>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public ApplicationUser Author { get; set; }

        public PostCategory Category { get; set; }

        public IEnumerable<TagViewModel> Tags { get; set; }

        public int CommentsCount { get; set; }

        public int Votes { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Post, PostHomeViewModel>()
                .ForMember(m => m.Category, opt => opt.MapFrom(x => x.PostCategory))
                .ForMember(m => m.CommentsCount, opt => opt.MapFrom(x => x.Comments.Count()))
                .ForMember(m => m.Votes, opt => opt.MapFrom(x => x.Votes.Sum(v => (int?)v.Value) ?? 0))
                .ReverseMap();
        }
    }
}
