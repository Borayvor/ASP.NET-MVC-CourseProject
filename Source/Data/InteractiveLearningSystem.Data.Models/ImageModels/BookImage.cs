namespace InteractiveLearningSystem.Data.Models.ImageModels
{
    using System.ComponentModel.DataAnnotations;
    using BookModels;

    public class BookImage
    {
        [Range(0, int.MaxValue)]
        public int Position { get; set; }

        [Required]
        public byte[] Image { get; set; }

        public int BookId { get; set; }

        public virtual Book Book { get; set; }
    }
}
