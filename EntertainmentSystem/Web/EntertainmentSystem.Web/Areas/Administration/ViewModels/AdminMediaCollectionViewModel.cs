namespace EntertainmentSystem.Web.Areas.Administration.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;
    using Data.Models.Media;
    using Infrastructure.Mapping;
    using Web.ViewModels;

    public class AdminMediaCollectionViewModel : BaseViewModel<Guid>, IMapFrom<MediaCollection>
    {
        [Display(Name = "Collection name")]
        [Required]
        [MinLength(GlobalConstants.MediaCollectionNameMinLength)]
        [MaxLength(GlobalConstants.MediaCollectionNameMaxLength)]
        public string Name { get; set; }
    }
}
