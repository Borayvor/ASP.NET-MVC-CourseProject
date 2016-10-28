namespace EntertainmentSystem.Web.ViewModels.Media
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;
    using Data.Models.Media;
    using Infrastructure.Mapping;

    public class MediaCollectionViewModel : BaseViewModel<Guid>, IMapFrom<MediaCollection>
    {
        [Display(Name = "Collection name")]
        [Required]
        [MinLength(GlobalConstants.MediaCollectionNameMinLength)]
        [MaxLength(GlobalConstants.MediaCollectionNameMaxLength)]
        public string Name { get; set; }
    }
}
