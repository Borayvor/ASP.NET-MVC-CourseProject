namespace EntertainmentSystem.Web.Areas.Administration.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Common.Constants;
    using Data.Models.Media;
    using Infrastructure.Mapping;

    public class AdminMediaContentEditViewModel : IMapFrom<MediaContent>, IMapTo<MediaContent>
    {
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.MediaContentTitleMinLength)]
        [MaxLength(GlobalConstants.MediaContentTitleMaxLength)]
        public string Title { get; set; }

        [MaxLength(GlobalConstants.MediaContentDescriptionMaxLength)]
        public string Description { get; set; }

        public bool IsDeleted { get; set; }
    }
}
