namespace EntertainmentSystem.Web.ViewModels.Media
{
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;
    using Data.Models.Media;
    using Infrastructure.Mapping;

    public class MediaCategoryCreateViewModel : IMapFrom<MediaCategory>, IMapTo<MediaCategory>
    {
        [Display(Name = "Category name")]
        [Required]
        [MinLength(GlobalConstants.MediaCategoryNameMinLength)]
        [MaxLength(GlobalConstants.MediaCategoryNameMaxLength)]
        public string Name { get; set; }
    }
}
