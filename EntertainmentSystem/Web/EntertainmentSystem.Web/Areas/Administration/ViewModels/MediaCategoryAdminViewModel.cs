namespace EntertainmentSystem.Web.Areas.Administration.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Data.Models.Media;
    using Infrastructure.Mapping;

    public class MediaCategoryAdminViewModel : AdminViewModel, IMapFrom<MediaCategory>
    {
        [Display(Name = "Category name")]
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
