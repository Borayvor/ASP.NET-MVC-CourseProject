namespace EntertainmentSystem.Web.Areas.Administration.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Common.Constants;
    using Data.Models.Media;
    using Infrastructure.Mapping;

    public class AdminMediaCategoryEditViewModel : IMapFrom<MediaCategory>, IMapTo<MediaCategory>
    {
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.MediaCategoryNameMinLength)]
        [MaxLength(GlobalConstants.MediaCategoryNameMaxLength)]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }
    }
}
