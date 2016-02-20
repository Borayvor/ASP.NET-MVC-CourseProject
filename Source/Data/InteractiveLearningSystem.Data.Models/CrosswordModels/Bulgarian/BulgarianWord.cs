namespace InteractiveLearningSystem.Data.Models.CrosswordModels.Bulgarian
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class BulgarianWord : BaseModel<int>
    {
        private ICollection<BulgarianQuestion> questions;

        public BulgarianWord()
        {
            this.questions = new HashSet<BulgarianQuestion>();
        }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        [RegularExpression(@"\b[а-яА-Я]+\b", ErrorMessage = "Думата трябва да съдържа само Български букви !")]
        public string Name { get; set; }

        public virtual ICollection<BulgarianQuestion> Questions
        {
            get { return this.questions; }
            set { this.questions = value; }
        }
    }
}
