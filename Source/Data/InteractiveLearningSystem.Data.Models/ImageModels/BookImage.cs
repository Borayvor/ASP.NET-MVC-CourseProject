namespace InteractiveLearningSystem.Data.Models.ImageModels
{
    using System.ComponentModel.DataAnnotations;
    using BookModels;

    public class BookImage
    {
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(5)]
        public string Extension { get; set; }

        [Range(0, int.MaxValue)]
        public int Position { get; set; }

        [Required]
        public byte[] Image { get; set; }

        public int BookId { get; set; }

        public virtual Book Book { get; set; }
    }
}
