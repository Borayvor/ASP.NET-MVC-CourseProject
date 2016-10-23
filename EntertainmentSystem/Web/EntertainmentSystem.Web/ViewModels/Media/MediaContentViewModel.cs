namespace EntertainmentSystem.Web.ViewModels.Media
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Data.Models.Media;
    using Infrastructure.Mapping;
    using Web.ViewModels;

    public class MediaContentViewModel : BaseViewModel<Guid>, IMapFrom<MediaContent>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public string Description { get; set; }

        [Display(Name = "File")]
        public string ContentUrl { get; set; }

        [Display(Name = "Type")]
        public string ContentType { get; set; }

        [Display(Name = "Category")]
        public string MediaCategory { get; set; }

        [Display(Name = "Collection")]
        public string MediaCollection { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<MediaContent, MediaContentViewModel>()
                .ForMember(m => m.ContentType, opt => opt.MapFrom(x => x.ContentType.ToString()))
                .ForMember(m => m.MediaCategory, opt => opt.MapFrom(x => x.MediaCategory.Name))
                .ForMember(m => m.MediaCollection, opt => opt.MapFrom(x => x.MediaCollection.Name))
                .ReverseMap();
        }
    }
}
