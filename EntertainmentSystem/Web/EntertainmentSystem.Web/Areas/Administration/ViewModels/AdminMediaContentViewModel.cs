namespace EntertainmentSystem.Web.Areas.Administration.ViewModels
{
    using AutoMapper;
    using Data.Models.Media;
    using Infrastructure.Mapping;

    public class AdminMediaContentViewModel : AdminBaseViewModel, IMapFrom<MediaContent>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string ContentUrl { get; set; }

        public string ContentType { get; set; }

        public string MediaCategory { get; set; }

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
