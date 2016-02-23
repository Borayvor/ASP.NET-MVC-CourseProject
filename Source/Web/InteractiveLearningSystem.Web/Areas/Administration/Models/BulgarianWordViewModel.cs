namespace InteractiveLearningSystem.Web.Areas.Administration.Models
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models.WordModels.Bulgarian;
    using Infrastructure.Mapping;

    public class BulgarianWordViewModel : IMapFrom<BulgarianWord>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(60)]
        [RegularExpression(@"[а-яА-Я]+", ErrorMessage = "Only Cyrillic alphabet !")]
        public string Name { get; set; }

        [UIHint("_Language")]
        public LanguageViewModel Language { get; set; }

        [UIHint("_BulgarianQuestion")]
        public BulgarianQuestionViewModel Question { get; set; }
    }
}
