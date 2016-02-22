namespace InteractiveLearningSystem.Data.Models.WordModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Bulgarian;
    using Common.Models;
    using English;

    public class Language : BaseModel<int>
    {
        private ICollection<BulgarianWord> bulgarianWords;
        private ICollection<EnglishWord> englishWords;

        public Language()
        {
            this.bulgarianWords = new HashSet<BulgarianWord>();
            this.englishWords = new HashSet<EnglishWord>();
        }

        [Required]
        [MinLength(1)]
        [MaxLength(60)]
        public string Name { get; set; }

        public virtual ICollection<BulgarianWord> BulgarianWords
        {
            get { return this.bulgarianWords; }
            set { this.bulgarianWords = value; }
        }

        public virtual ICollection<EnglishWord> EnglishWords
        {
            get { return this.englishWords; }
            set { this.englishWords = value; }
        }
    }
}
