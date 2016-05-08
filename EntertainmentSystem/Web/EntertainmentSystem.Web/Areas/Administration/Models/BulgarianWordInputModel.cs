namespace EntertainmentSystem.Web.Areas.Administration.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Data.Models.WordModels.Bulgarian;
    using Infrastructure.Mapping;

    public class BulgarianWordInputModel : IMapTo<BulgarianWord>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(60)]
        [RegularExpression(@"[а-яА-Я]+", ErrorMessage = "Only Cyrillic alphabet !")]
        public string Name { get; set; }

        public int LanguageId { get; set; }
    }
}
