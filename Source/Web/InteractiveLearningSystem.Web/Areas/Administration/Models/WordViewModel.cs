namespace InteractiveLearningSystem.Web.Areas.Administration.Models
{
    using System.ComponentModel.DataAnnotations;

    public class WordViewModel
    {
        public int Id { get; set; }

        [MinLength(1)]
        [MaxLength(60)]
        [RegularExpression(@"\b[а-яА-Я]+\b", ErrorMessage = "Думата трябва да съдържа само Български букви !")]
        public string Name { get; set; }
    }
}