namespace EntertainmentSystem.Web.Areas.Administration.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Common.Constants;
    using Data.Models.Media;
    using Infrastructure.Mapping;
    using Web.ViewModels;

    public class AdminMediaContentViewModel : BaseViewModel<Guid>, IMapFrom<MediaContent>, IHaveCustomMappings
    {
        [Required]
        [MinLength(GlobalConstants.MediaContentTitleMinLength)]
        [MaxLength(GlobalConstants.MediaContentTitleMaxLength)]
        public string Title { get; set; }

        [MaxLength(GlobalConstants.MediaContentDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "File")]
        [DataType(DataType.ImageUrl)]
        [MinLength(GlobalConstants.MediaContentContentUrlMinLength)]
        [MaxLength(GlobalConstants.MediaContentContentUrlMaxLength)]
        public string ContentUrl { get; set; }

        [Display(Name = "Type")]
        public string ContentType { get; set; }

        [Required]
        [Display(Name = "Category")]
        [MinLength(GlobalConstants.MediaCategoryNameMinLength)]
        [MaxLength(GlobalConstants.MediaCategoryNameMaxLength)]
        public string MediaCategory { get; set; }

        [Required]
        [Display(Name = "Collection")]
        [MinLength(GlobalConstants.MediaCollectionNameMinLength)]
        [MaxLength(GlobalConstants.MediaCollectionNameMaxLength)]
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
