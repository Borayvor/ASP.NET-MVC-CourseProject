namespace EntertainmentSystem.Web.Areas.Administration.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Data.Models.Media;
    using Infrastructure.Mapping;
    using Web.ViewModels;

    public class AdminMediaCategoryViewModel : BaseViewModel<Guid>, IMapFrom<MediaCategory>
    {
        [Display(Name = "Category name")]
        public string Name { get; set; }
    }
}
