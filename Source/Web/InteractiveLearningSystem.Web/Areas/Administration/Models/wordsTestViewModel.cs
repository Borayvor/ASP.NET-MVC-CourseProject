namespace InteractiveLearningSystem.Web.Areas.Administration.Models
{
    using System.ComponentModel.DataAnnotations;

    public class WordsTestViewModel
    {
        [UIHint("Language")]
        public LanguageViewModel Language { get; set; }

        [UIHint("BulgarianWord")]
        public BulgarianWordViewModel Word { get; set; }

        [UIHint("BulgarianQuestion")]
        public BulgarianQuestionViewModel Question { get; set; }
    }
}
