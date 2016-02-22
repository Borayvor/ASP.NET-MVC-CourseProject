namespace InteractiveLearningSystem.Web.Areas.Administration.Models
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models.WordModels;

    public class BulgarianWordInputModel
    {
        [Required]
        [MinLength(1)]
        [MaxLength(60)]
        [RegularExpression(@"[а-яА-Я]+", ErrorMessage = "Only Cyrillic alphabet !")]
        public string Name { get; set; }

        [Required]
        public Language Language { get; set; }
    }
}