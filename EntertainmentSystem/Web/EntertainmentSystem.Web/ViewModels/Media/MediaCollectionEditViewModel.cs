namespace EntertainmentSystem.Web.ViewModels.Media
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Data.Models.Media;
    using Infrastructure.Mapping;

    public class MediaCollectionEditViewModel : IMapFrom<MediaCollection>, IMapTo<MediaCollection>
    {
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(500)]
        public string Name { get; set; }
    }
}
