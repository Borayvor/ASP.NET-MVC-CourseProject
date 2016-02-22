namespace InteractiveLearningSystem.Data.Models.ImageModels
{
    using System.ComponentModel.DataAnnotations;
    using ComicsModels;

    public class ComicsImage
    {
        [Range(0, int.MaxValue)]
        public int Position { get; set; }

        [Required]
        public byte[] Image { get; set; }

        public int ComicsId { get; set; }

        public Comics Comics { get; set; }
    }
}
