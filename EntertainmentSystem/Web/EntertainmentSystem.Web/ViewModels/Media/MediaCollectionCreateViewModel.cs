namespace EntertainmentSystem.Web.ViewModels.Media
{
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;
    using Data.Models.Media;
    using Infrastructure.Mapping;

    public class MediaCollectionCreateViewModel : IMapFrom<MediaCollection>, IMapTo<MediaCollection>
    {
        [Required]
        [MinLength(GlobalConstants.MediaCollectionNameMinLength)]
        [MaxLength(GlobalConstants.MediaCollectionNameMaxLength)]
        public string Name { get; set; }
    }
}
