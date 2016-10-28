namespace EntertainmentSystem.Web.ViewModels.Media
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Data.Models.Media;
    using Infrastructure.Mapping;

    public class MediaCollectionViewModel : BaseViewModel<Guid>, IMapFrom<MediaCollection>
    {
        [Display(Name = "Collection name")]
        [Required]
        [MinLength(1)]
        [MaxLength(500)]
        public string Name { get; set; }
    }
}
