namespace EntertainmentSystem.Web.Areas.Administration.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Data.Models.Media;
    using Infrastructure.Mapping;

    public class AdminMediaContentViewModel : AdminBaseGuidViewModel, IMapFrom<MediaContent>, IHaveCustomMappings
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
            configuration.CreateMap<MediaContent, AdminMediaContentViewModel>()
                .ForMember(m => m.ContentType, opt => opt.MapFrom(x => x.ContentType.ToString()))
                .ForMember(m => m.MediaCategory, opt => opt.MapFrom(x => x.MediaCategory.Name))
                .ForMember(m => m.MediaCollection, opt => opt.MapFrom(x => x.MediaCollection.Name))
                .ReverseMap();
        }
    }
}
