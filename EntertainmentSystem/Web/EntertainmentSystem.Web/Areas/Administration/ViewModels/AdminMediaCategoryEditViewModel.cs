﻿namespace EntertainmentSystem.Web.Areas.Administration.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Data.Models.Media;
    using Infrastructure.Mapping;

    public class AdminMediaCategoryEditViewModel : IMapFrom<MediaCategory>, IMapTo<MediaCategory>
    {
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string Name { get; set; }
    }
}
