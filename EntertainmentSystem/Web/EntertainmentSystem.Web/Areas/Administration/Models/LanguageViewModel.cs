namespace EntertainmentSystem.Web.Areas.Administration.Models
{
    using System;
    using System.Web.Mvc;
    using Data.Models.WordModels;
    using Infrastructure.Mapping;

    public class LanguageViewModel : IMapFrom<Language>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Name { get; set; }

        [HiddenInput(DisplayValue = false)]
        public DateTime CreatedOn { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool IsDeleted { get; set; }

        [HiddenInput(DisplayValue = false)]
        public DateTime? ModifiedOn { get; set; }
    }
}
