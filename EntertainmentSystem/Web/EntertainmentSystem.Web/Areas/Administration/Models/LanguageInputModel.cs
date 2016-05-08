namespace EntertainmentSystem.Web.Areas.Administration.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Data.Models.WordModels;
    using Infrastructure.Mapping;

    public class LanguageInputModel : IMapTo<Language>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(60)]
        public string Name { get; set; }
    }
}
