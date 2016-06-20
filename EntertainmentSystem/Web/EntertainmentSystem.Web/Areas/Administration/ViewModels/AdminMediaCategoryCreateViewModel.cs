﻿namespace EntertainmentSystem.Web.Areas.Administration.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models.Media;
    using Infrastructure.Mapping;

    public class AdminMediaCategoryCreateViewModel : IMapFrom<MediaCategory>, IMapTo<MediaCategory>
    {
        [Required]
        [MaxLength(500)]
        [Display(Name = "Category name")]
        public string Name { get; set; }
    }
}