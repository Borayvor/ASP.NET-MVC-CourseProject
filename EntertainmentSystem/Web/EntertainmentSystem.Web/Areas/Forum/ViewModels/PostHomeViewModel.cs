namespace EntertainmentSystem.Web.Areas.Forum.ViewModels
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Data.Models;
    using Data.Models.Forum;
    using Infrastructure.Mapping;
    using Web.ViewModels;

    public class PostHomeViewModel : BaseViewModel<Guid>, IMapFrom<Post>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public ApplicationUser Author { get; set; }

        public Category Category { get; set; }

        public IEnumerable<Tag> Tags { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        public IEnumerable<Vote> Votes { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Post, PostHomeViewModel>()
                .ForMember(m => m.Category, opt => opt.MapFrom(x => x.PostCategory))
                .ForMember(m => m.Tags, opt => opt.MapFrom(x => x.PostTags))
                .ReverseMap();
        }
    }
}
