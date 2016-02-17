namespace InteractiveLearningSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Word
    {
        private ICollection<Question> questions;

        private ICollection<Crossword> crosswords;

        public Word()
        {
            this.questions = new HashSet<Question>();
            this.crosswords = new HashSet<Crossword>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        [RegularExpression(@"\b[а-яА-Я]+\b", ErrorMessage = "Думата трябва да съдържа само букви от Кирилицата !")]
        public string Name { get; set; }

        public virtual Crossword Crossword { get; set; }

        public virtual ICollection<Question> Questions
        {
            get { return this.questions; }
            set { this.questions = value; }
        }

        public virtual ICollection<Crossword> Crosswords
        {
            get { return this.crosswords; }
            set { this.crosswords = value; }
        }
    }
}
