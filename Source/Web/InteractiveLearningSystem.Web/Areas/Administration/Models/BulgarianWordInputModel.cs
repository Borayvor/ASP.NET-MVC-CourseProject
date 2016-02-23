namespace InteractiveLearningSystem.Web.Areas.Administration.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class BulgarianWordInputModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(60)]
        [RegularExpression(@"[а-яА-Я]+", ErrorMessage = "Only Cyrillic alphabet !")]
        public string Name { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int LanguageId { get; set; }
    }
}
