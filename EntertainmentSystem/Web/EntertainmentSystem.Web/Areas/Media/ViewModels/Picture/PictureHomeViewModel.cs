namespace EntertainmentSystem.Web.Areas.Media.ViewModels.Picture
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Data.Models.Media;
    using Infrastructure.Mapping;
    using Web.ViewModels;

    public class PictureHomeViewModel : BaseViewModel<Guid>, IMapFrom<MediaContent>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public string Description { get; set; }

        [Display(Name = "File")]
        public string ContentUrl { get; set; }

        public string Category { get; set; }

        public string Collection { get; set; }

        public string Author { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<MediaContent, PictureHomeViewModel>()
                .ForMember(m => m.Category, opt => opt.MapFrom(x => x.MediaCategory.Name))
                .ForMember(m => m.Collection, opt => opt.MapFrom(x => x.MediaCollection.Name))
                .ForMember(m => m.Author, opt => opt.MapFrom(x => x.Author.UserName))
                .ReverseMap();
        }
    }
}
