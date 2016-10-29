namespace EntertainmentSystem.Web.Areas.Media.ViewModels
{
    using System;
    using AutoMapper;
    using Data.Models.Media;
    using Infrastructure.Mapping;
    using Web.ViewModels;

    public class MediaDetailsViewModel : BaseViewModel<Guid>,
        IMapFrom<MediaContent>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string ContentUrl { get; set; }

        public string CoverImageUrl { get; set; }

        public string Author { get; set; }

        public string Category { get; set; }

        public string Collection { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<MediaContent, MediaDetailsViewModel>()
                .ForMember(m => m.Author, opt => opt.MapFrom(x => x.Author.UserName))
                .ForMember(m => m.Category, opt => opt.MapFrom(x => x.MediaCategory.Name))
                .ForMember(m => m.Collection, opt => opt.MapFrom(x => x.MediaCollection.Name))
                .ReverseMap();
        }
    }
}
