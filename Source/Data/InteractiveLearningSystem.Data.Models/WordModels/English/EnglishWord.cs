namespace InteractiveLearningSystem.Data.Models.WordModels.English
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;

    public class EnglishWord : BaseModel<int>
    {
        private ICollection<EnglishQuestion> questions;

        public EnglishWord()
        {
            this.questions = new HashSet<EnglishQuestion>();
        }

        [Required]
        [MinLength(1)]
        [MaxLength(60)]
        [Index(IsUnique = true)]
        [RegularExpression(@"\b[a-zA-Z]+\b", ErrorMessage = "The word should contain only English letters !")]
        public string Name { get; set; }

        public virtual ICollection<EnglishQuestion> Questions
        {
            get { return this.questions; }
            set { this.questions = value; }
        }
    }
}
