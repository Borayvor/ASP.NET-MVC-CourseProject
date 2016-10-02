namespace EntertainmentSystem.Web.Areas.Administration.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models.Media;
    using Infrastructure.Mapping;

    public class AdminMediaCategoryViewModel : AdminBaseGuidViewModel, IMapFrom<MediaCategory>
    {
        [Display(Name = "Category name")]
        public string Name { get; set; }
    }
}
