namespace EntertainmentSystem.Web.ViewModels.Media
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Data.Models.Media;
    using Infrastructure.Mapping;
    using Web.ViewModels;

    public class MediaCategoryViewModel : BaseViewModel<Guid>, IMapFrom<MediaCategory>
    {
        [Display(Name = "Category name")]
        public string Name { get; set; }
    }
}
