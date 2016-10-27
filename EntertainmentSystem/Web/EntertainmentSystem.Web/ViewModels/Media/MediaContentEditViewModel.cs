namespace EntertainmentSystem.Web.ViewModels.Media
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Data.Models.Media;
    using Infrastructure.Mapping;

    public class MediaContentEditViewModel : IMapFrom<MediaContent>, IMapTo<MediaContent>
    {
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(250)]
        public string Title { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }
    }
}
