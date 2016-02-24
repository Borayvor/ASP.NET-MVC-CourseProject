namespace InteractiveLearningSystem.Data.Models.ImageModels
{
    using System.ComponentModel.DataAnnotations;
    using ComicsModels;
    using Common.Models;

    public class ComicsImage : BaseModel<int>
    {
        [Required]
        [MinLength(1)]
        [MaxLength(500)]
        public string FileName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(5)]
        public string Extension { get; set; }

        //[Index]
        //[Range(0, int.MaxValue)]
        //public int Position { get; set; }

        [Required]
        public byte[] Image { get; set; }

        public int ComicsId { get; set; }

        public virtual Comics Comics { get; set; }
    }
}
