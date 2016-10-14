namespace EntertainmentSystem.Web.Areas.Forum.ViewModels
{
    using System;
    using AutoMapper;
    using Data.Models.Forum;
    using Infrastructure.Mapping;
    using Web.ViewModels;

    public class PostHomeViewModel : BaseViewModel<Guid>, IMapFrom<Post>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public string Category { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Post, PostHomeViewModel>()
                .ForMember(m => m.Author, opt => opt.MapFrom(x => x.Author.UserName))
                .ForMember(m => m.Category, opt => opt.MapFrom(x => x.PostCategory.Name))
                .ReverseMap();
        }
    }
}
