namespace EntertainmentSystem.Web.Areas.Forum.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using AutoMapper;
    using Data.Models;
    using Data.Models.Forum;
    using Infrastructure.Mapping;
    using Web.ViewModels;

    public class PostViewModel : BaseViewModel<Guid>, IMapFrom<Post>, IHaveCustomMappings
    {
        public string Title { get; set; }

        [UIHint("tinymce")]
        public string Content { get; set; }

        public ApplicationUser Author { get; set; }

        public PostCategory Category { get; set; }

        public IEnumerable<TagViewModel> Tags { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public int Votes { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Post, PostViewModel>()
                .ForMember(m => m.Category, opt => opt.MapFrom(x => x.PostCategory))
                .ForMember(m => m.Votes, opt => opt.MapFrom(x => x.Votes.Sum(v => (int)v.Value)))
                .ReverseMap();
        }
    }
}
