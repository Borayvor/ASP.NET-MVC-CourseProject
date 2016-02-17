namespace InteractiveLearningSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Question
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(500)]
        public string Name { get; set; }

        public int WordId { get; set; }

        public virtual Word Word { get; set; }
    }
}
