namespace EntertainmentSystem.Web.Areas.Administration.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Data.Models.Media;
    using Infrastructure.Mapping;

    public class AdminMediaContentEditViewModel : IMapFrom<MediaContent>, IMapTo<MediaContent>
    {
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }

        [MaxLength(250)]
        public string Title { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }
    }
}
