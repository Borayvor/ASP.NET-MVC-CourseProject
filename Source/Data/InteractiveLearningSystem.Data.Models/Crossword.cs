namespace InteractiveLearningSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Crossword
    {
        private ICollection<Word> words;

        public Crossword()
        {
            this.words = new HashSet<Word>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        [Range(2, 200)]
        public int NumberOfWords { get; set; }

        public virtual ICollection<Word> Words
        {
            get { return this.words; }
            set { this.words = value; }
        }
    }
}
