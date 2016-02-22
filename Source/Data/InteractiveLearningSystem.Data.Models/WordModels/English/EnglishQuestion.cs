namespace InteractiveLearningSystem.Data.Models.WordModels.English
{
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class EnglishQuestion : BaseModel<int>
    {
        [Required]
        [MinLength(1)]
        [MaxLength(500)]
        public string Content { get; set; }

        public int WordId { get; set; }

        public virtual EnglishWord Word { get; set; }
    }
}
