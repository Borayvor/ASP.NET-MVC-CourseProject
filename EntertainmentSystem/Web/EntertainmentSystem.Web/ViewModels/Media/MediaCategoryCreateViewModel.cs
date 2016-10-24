﻿namespace EntertainmentSystem.Web.ViewModels.Media
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models.Media;
    using Infrastructure.Mapping;

    public class MediaCategoryCreateViewModel : IMapFrom<MediaCategory>, IMapTo<MediaCategory>
    {
        [Required]
        [MaxLength(500)]
        public string Name { get; set; }
    }
}