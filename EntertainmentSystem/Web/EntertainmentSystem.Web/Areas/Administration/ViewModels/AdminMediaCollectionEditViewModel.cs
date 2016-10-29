namespace EntertainmentSystem.Web.Areas.Administration.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Common.Constants;
    using Data.Models.Media;
    using Infrastructure.Mapping;

    public class AdminMediaCollectionEditViewModel : IMapFrom<MediaCollection>, IMapTo<MediaCollection>
    {
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.MediaCollectionNameMinLength)]
        [MaxLength(GlobalConstants.MediaCollectionNameMaxLength)]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }
    }
}
