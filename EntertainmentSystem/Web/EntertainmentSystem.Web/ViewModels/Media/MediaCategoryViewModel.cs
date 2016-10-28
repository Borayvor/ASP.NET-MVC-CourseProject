namespace EntertainmentSystem.Web.ViewModels.Media
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;
    using Data.Models.Media;
    using Infrastructure.Mapping;
    using Web.ViewModels;

    public class MediaCategoryViewModel : BaseViewModel<Guid>, IMapFrom<MediaCategory>
    {
        [Display(Name = "Category name")]
        [Required]
        [MinLength(GlobalConstants.MediaCategoryNameMinLength)]
        [MaxLength(GlobalConstants.MediaCategoryNameMaxLength)]
        public string Name { get; set; }
    }
}
